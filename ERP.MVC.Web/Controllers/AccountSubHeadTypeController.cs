using ERP.MVC.Application.Commands.AccountSubHeadTypes;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Application.Queries.AccountHeadTypes;
using ERP.MVC.Application.Queries.AccountSubHeadTypes;
using ERP.MVC.Application.Queries.Branches;
using ERP.MVC.Application.Queries.Company;
using ERP.MVC.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ERP.MVC.Web.Controllers
{
    public class AccountSubHeadTypeController : Controller
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILogger<AccountSubHeadTypeController> _logger;

        #endregion

        #region Ctor

        public AccountSubHeadTypeController(IMediator mediator, ILogger<AccountSubHeadTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #endregion

        #region Methods

        // GET: AccountSubHeadType/AccountSubHeadType-List
        [HttpGet]
        public async Task<IActionResult> AccountSubHeadTypeList(string search = "", int page = 1, int pageSize = 10, string sortField = "AccountSubHeadTypeName", string sortOrder = "asc")
        {
            var accountsSubHeadTypes = await _mediator.Send(new GetAccountsSubHeadTypesQuery());
            var companies = await _mediator.Send(new GetCompaniesQuery());
            var branches = await _mediator.Send(new GetBranchesQuery());
            var accountsHeadTypes = await _mediator.Send(new GetAccountsHeadTypesQuery());

            // Filter AccountHeadTypes based on the search query
            var filteredAccountSubHeadTypes = string.IsNullOrEmpty(search)
                ? accountsSubHeadTypes
                : accountsSubHeadTypes.Where(c => !string.IsNullOrEmpty(c.AccountSubHeadTypeName) && c.AccountSubHeadTypeName.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            // Apply sorting
            switch (sortField)
            {
                case "CompanyName":
                    filteredAccountSubHeadTypes = sortOrder == "asc"
                        ? filteredAccountSubHeadTypes.OrderBy(c => c.CompanyName).ToList()
                        : filteredAccountSubHeadTypes.OrderByDescending(c => c.CompanyName).ToList();
                    break;
                case "BranchName":
                    filteredAccountSubHeadTypes = sortOrder == "asc"
                        ? filteredAccountSubHeadTypes.OrderBy(c => c.BranchName).ToList()
                        : filteredAccountSubHeadTypes.OrderByDescending(c => c.BranchName).ToList();
                    break;
                case "AccountHeadTypeName":
                    filteredAccountSubHeadTypes = sortOrder == "asc"
                        ? filteredAccountSubHeadTypes.OrderBy(c => c.AccountHeadTypeName).ToList()
                        : filteredAccountSubHeadTypes.OrderByDescending(c => c.AccountHeadTypeName).ToList();
                    break;
                case "AccountSubHeadTypeName":
                    filteredAccountSubHeadTypes = sortOrder == "asc"
                        ? filteredAccountSubHeadTypes.OrderBy(c => c.AccountSubHeadTypeName).ToList()
                        : filteredAccountSubHeadTypes.OrderByDescending(c => c.AccountSubHeadTypeName).ToList();
                    break;
                case "IsActive":
                    filteredAccountSubHeadTypes = sortOrder == "asc"
                        ? filteredAccountSubHeadTypes.OrderBy(c => c.IsActive).ToList()
                        : filteredAccountSubHeadTypes.OrderByDescending(c => c.IsActive).ToList();
                    break;
            }

            var totalEntries = filteredAccountSubHeadTypes.Count();
            var pagedAccountSubHeadTypes = filteredAccountSubHeadTypes.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalEntries = totalEntries;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchQuery = search;
            ViewBag.SortField = sortField;
            ViewBag.SortOrder = sortOrder;

            return View(pagedAccountSubHeadTypes);
        }

        // GET: AccountSubHeadType/AccountSubHeadTypeView
        [HttpGet]
        public async Task<IActionResult> AccountSubHeadTypeView()
        {
            // Fetch companies for the company dropdown
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");

            // Initially set empty lists for Branches and Account Head Types
            ViewBag.Branches = new SelectList(new List<BranchDto>(), "Id", "BranchName");
            ViewBag.AccountHeadTypes = new SelectList(new List<AccountsHeadTypeDto>(), "Id", "AccountHeadTypeName");

            return View(new AccountsSubHeadTypeDto());
        }

        //POST: AccountSubHeadType/AccountSubHeadType-View     
        [HttpPost]
        public async Task<IActionResult> AccountSubHeadTypeView([FromForm] AccountsSubHeadTypeDto accountsSubHeadTypeDto)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateAccountSubHeadTypeCommand
                {
                    CompanyId = accountsSubHeadTypeDto.CompanyId,
                    BranchId = accountsSubHeadTypeDto.BranchId,
                    AccountHeadTypeId = accountsSubHeadTypeDto.AccountHeadTypeId,
                    AccountSubHeadTypeName = accountsSubHeadTypeDto.AccountSubHeadTypeName,
                    IsActive = accountsSubHeadTypeDto.IsActive,
                    IsDelete = true
                };

                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    var alertMessage = new AlertMessage { Message = "New Information has been saved!", AlertType = "success" };
                    TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
                    return RedirectToAction("AccountSubHeadTypeList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            // Re-fetch companies in case of failure
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");

            return View(accountsSubHeadTypeDto);
        }


        // GET: AccountSubHeadType/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var accountsSubHeadType = await _mediator.Send(new GetAccountSubHeadTypeByIdQuery { Id = id });
            if (accountsSubHeadType == null)
                return NotFound();

            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");

            var branches = await _mediator.Send(new GetBranchByCompanyIdQuery { CompanyId = accountsSubHeadType.CompanyId });
            ViewBag.Branches = branches;

            var accountsHeadTypes = await _mediator.Send(new GetAccountHeadTypeByCompanyIdQuery { CompanyId=accountsSubHeadType.CompanyId});
            ViewBag.AccountHeadTypes = accountsHeadTypes;

            return View("AccountSubHeadTypeView", accountsSubHeadType);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, [FromForm] AccountsSubHeadTypeDto accountsSubHeadTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(accountsSubHeadTypeDto);
            }

            var command = new UpdateAccountSubHeadTypeCommand
            {
                Id = id,
                CompanyId = accountsSubHeadTypeDto.CompanyId,
                BranchId = accountsSubHeadTypeDto.BranchId,
                AccountHeadTypeId = accountsSubHeadTypeDto.AccountHeadTypeId,
                AccountSubHeadTypeName = accountsSubHeadTypeDto.AccountSubHeadTypeName,
                IsActive = accountsSubHeadTypeDto.IsActive,
                IsDelete = true
            };

            await _mediator.Send(command);
            var alertMessage = new AlertMessage { Message = "Update has been saved!", AlertType = "success" };
            TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
            return RedirectToAction("AccountSubHeadTypeList");
        }

        // GET: AccountSubHeadType/GetBranchesByCompanyId/{companyId}
        [HttpGet]
        public async Task<IActionResult> GetBranchesByCompanyId(string companyId)
        {
            if (string.IsNullOrEmpty(companyId))
            {
                return Json(new { success = false, message = "Company ID is required" });
            }

            var branches = await _mediator.Send(new GetBranchByCompanyIdQuery { CompanyId = companyId });
            return Json(new { success = true, branches });
        }

        // GET: AccountSubHeadType/GetAccountHeadTypesByCompanyId/{companyId}
        [HttpGet]
        public async Task<IActionResult> GetAccountHeadTypesByCompanyId(string companyId)
        {
            if (string.IsNullOrEmpty(companyId))
            {
                return Json(new { success = false, message = "Company ID is required" });
            }

            var accountHeadTypes = await _mediator.Send(new GetAccountHeadTypeByCompanyIdQuery { CompanyId = companyId });
            return Json(new { success = true, accountHeadTypes });
        }


        #endregion


    }
}
