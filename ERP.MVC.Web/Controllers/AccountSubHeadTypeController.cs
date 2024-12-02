using ERP.MVC.Application.Commands.AccountHeadTypes;
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
        public async Task<IActionResult> AccountSubHeadTypeList(string search = "", int page = 1, int pageSize = 10, string sortField = "AccountHeadTypeName", string sortOrder = "asc")
        {
            var accountsSubHeadTypes = await _mediator.Send(new GetAccountsSubHeadTypesQuery());
            var companies = await _mediator.Send(new GetCompaniesQuery());
            var branches = await _mediator.Send(new GetBranchesQuery());
            var accountsHeadTypes = await _mediator.Send(new GetAccountsHeadTypesQuery());

            // Filter AccountHeadTypes based on the search query
            var filteredAccountHeadTypes = string.IsNullOrEmpty(search)
                ? accountsHeadTypes
                : accountsHeadTypes.Where(c => !string.IsNullOrEmpty(c.AccountHeadTypeName) && c.AccountHeadTypeName.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            // Apply sorting
            switch (sortField)
            {
                case "CompanyName":
                    filteredAccountHeadTypes = sortOrder == "asc"
                        ? filteredAccountHeadTypes.OrderBy(c => c.CompanyName).ToList()
                        : filteredAccountHeadTypes.OrderByDescending(c => c.CompanyName).ToList();
                    break;
                case "AccountHeadTypeName":
                    filteredAccountHeadTypes = sortOrder == "asc"
                        ? filteredAccountHeadTypes.OrderBy(c => c.AccountHeadTypeName).ToList()
                        : filteredAccountHeadTypes.OrderByDescending(c => c.AccountHeadTypeName).ToList();
                    break;
                case "IsActive":
                    filteredAccountHeadTypes = sortOrder == "asc"
                        ? filteredAccountHeadTypes.OrderBy(c => c.IsActive).ToList()
                        : filteredAccountHeadTypes.OrderByDescending(c => c.IsActive).ToList();
                    break;
            }

            var totalEntries = filteredAccountHeadTypes.Count();
            var pagedAccountHeadTypes = filteredAccountHeadTypes.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalEntries = totalEntries;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchQuery = search;
            ViewBag.SortField = sortField;
            ViewBag.SortOrder = sortOrder;

            return View(pagedAccountHeadTypes);
        }

        // GET: AccountSubHeadType/AccountSubHeadType-View
        [HttpGet]
        public async Task<IActionResult> AccountSubHeadTypeView()
        {
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");
            return View(new AccountsHeadTypeDto());
        }

        //POST: AccountSubHeadType/AccountSubHeadType-View     
        [HttpPost]
        public async Task<IActionResult> AccountHeadTypeView([FromForm] AccountsHeadTypeDto accountsHeadTypeDto)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateAccountHeadTypeCommand
                {
                    CompanyId = accountsHeadTypeDto.CompanyId,
                    AccountHeadTypeName = accountsHeadTypeDto.AccountHeadTypeName,
                    IsActive = accountsHeadTypeDto.IsActive,
                    IsDelete = true
                };

                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    var alertMessage = new AlertMessage { Message = "New Information has been saved!", AlertType = "success" };
                    TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
                    return RedirectToAction("AccountHeadTypeList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");

            return View(accountsHeadTypeDto);
        }


        // GET: AccountSubHeadType/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");
            var accountsHeadType = await _mediator.Send(new GetAccountHeadTypeByIdQuery { Id = id });
            if (accountsHeadType == null)
                return NotFound();
            return View("AccountHeadTypeView", accountsHeadType);
        }

        // POST: AccountSubHeadType/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [FromForm] AccountsHeadTypeDto accountsHeadTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(accountsHeadTypeDto);
            }

            var command = new UpdateAccountHeadTypeCommand
            {
                Id = id,
                CompanyId = accountsHeadTypeDto.CompanyId,
                AccountHeadTypeName = accountsHeadTypeDto.AccountHeadTypeName,
                IsActive = accountsHeadTypeDto.IsActive,
                IsDelete = true
            };

            await _mediator.Send(command);
            var alertMessage = new AlertMessage { Message = "Update has been saved!", AlertType = "success" };
            TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
            return RedirectToAction("AccountHeadTypeList");
        }




        #endregion


    }
}
