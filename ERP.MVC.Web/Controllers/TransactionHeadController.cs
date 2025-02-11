using ERP.MVC.Application.Commands.TransactionHeads;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Application.Queries.AccountHeadTypes;
using ERP.MVC.Application.Queries.AccountSubHeadTypes;
using ERP.MVC.Application.Queries.Branches;
using ERP.MVC.Application.Queries.Company;
using ERP.MVC.Application.Queries.TransactionHeads;
using ERP.MVC.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ERP.MVC.Web.Controllers
{
    public class TransactionHeadController : Controller
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILogger<TransactionHeadController> _logger;

        #endregion

        #region Ctor

        public TransactionHeadController(IMediator mediator, ILogger<TransactionHeadController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #endregion

        #region Methods

        // GET: TransactionHead/TransactionHead-List
        [HttpGet]
        public async Task<IActionResult> TransactionHeadList(string search = "", int page = 1, int pageSize = 10, string sortField = "TransactionHeadName", string sortOrder = "asc")
        {
            var transactionHeads = await _mediator.Send(new GetTransactionHeadsQuery());
            var companies = await _mediator.Send(new GetCompaniesQuery());
            var branches = await _mediator.Send(new GetBranchesQuery());
            var accountsHeadTypes = await _mediator.Send(new GetAccountsHeadTypesQuery());
            var accountsSubHeadTypes = await _mediator.Send(new GetAccountsSubHeadTypesQuery());

            // Filter TransactionHead based on the search query
            var filteredtransactionHeads = string.IsNullOrEmpty(search)
                ? transactionHeads
                : transactionHeads.Where(c => !string.IsNullOrEmpty(c.TransactionHeadName) && c.TransactionHeadName.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            // Apply sorting
            switch (sortField)
            {
                case "CompanyName":
                    filteredtransactionHeads = sortOrder == "asc"
                        ? filteredtransactionHeads.OrderBy(c => c.CompanyName).ToList()
                        : filteredtransactionHeads.OrderByDescending(c => c.CompanyName).ToList();
                    break;
                case "BranchName":
                    filteredtransactionHeads = sortOrder == "asc"
                        ? filteredtransactionHeads.OrderBy(c => c.BranchName).ToList()
                        : filteredtransactionHeads.OrderByDescending(c => c.BranchName).ToList();
                    break;
                case "AccountHeadTypeName":
                    filteredtransactionHeads = sortOrder == "asc"
                        ? filteredtransactionHeads.OrderBy(c => c.AccountHeadTypeName).ToList()
                        : filteredtransactionHeads.OrderByDescending(c => c.AccountHeadTypeName).ToList();
                    break;
                case "AccountSubHeadTypeName":
                    filteredtransactionHeads = sortOrder == "asc"
                        ? filteredtransactionHeads.OrderBy(c => c.AccountSubHeadTypeName).ToList()
                        : filteredtransactionHeads.OrderByDescending(c => c.AccountSubHeadTypeName).ToList();
                    break;
                case "TransactionHeadName":
                    filteredtransactionHeads = sortOrder == "asc"
                        ? filteredtransactionHeads.OrderBy(c => c.TransactionHeadName).ToList()
                        : filteredtransactionHeads.OrderByDescending(c => c.TransactionHeadName).ToList();
                    break;
                case "IsActive":
                    filteredtransactionHeads = sortOrder == "asc"
                        ? filteredtransactionHeads.OrderBy(c => c.IsActive).ToList()
                        : filteredtransactionHeads.OrderByDescending(c => c.IsActive).ToList();
                    break;
            }

            var totalEntries = filteredtransactionHeads.Count();
            var pagedTransactionHeadss = filteredtransactionHeads.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalEntries = totalEntries;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchQuery = search;
            ViewBag.SortField = sortField;
            ViewBag.SortOrder = sortOrder;

            return View(pagedTransactionHeadss);
        }

        // GET: TransactionHead/TransactionHeadView
        [HttpGet]
        public async Task<IActionResult> TransactionHeadView()
        {
            // Fetch companies for the company dropdown
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");

            // Initially set empty lists for Branches and Account Head Types
            ViewBag.Branches = new SelectList(new List<BranchDto>(), "Id", "BranchName");
            ViewBag.AccountHeadTypes = new SelectList(new List<AccountsHeadTypeDto>(), "Id", "AccountHeadTypeName");
            ViewBag.AccountSubHeadTypes = new SelectList(new List<AccountsSubHeadTypeDto>(), "Id", "AccountSubHeadTypeName");

            return View(new TransactionHeadDto());
        }

        //POST: TransactionHead/TransactionHead-View     
        [HttpPost]
        public async Task<IActionResult> TransactionHeadView([FromForm] TransactionHeadDto transactionHeadDto)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateTransactionHeadCommand
                {
                    CompanyId = transactionHeadDto.CompanyId,
                    BranchId = transactionHeadDto.BranchId,
                    AccountHeadTypeId = transactionHeadDto.AccountHeadTypeId,
                    AccountSubHeadTypeId = transactionHeadDto.AccountSubHeadTypeId,
                    TransactionHeadName = transactionHeadDto.TransactionHeadName,
                    IsActive = transactionHeadDto.IsActive,
                    IsDelete = true
                };

                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    var alertMessage = new AlertMessage { Message = "New Information has been saved!", AlertType = "success" };
                    TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
                    return RedirectToAction("TransactionHeadList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            // Re-fetch companies in case of failure
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");

            return View(transactionHeadDto);
        }


        // GET: TransactionHead/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var transactionHead = await _mediator.Send(new GetTransactionHeadByIdQuery { Id = id });
            if (transactionHead == null)
                return NotFound();

            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName", transactionHead.CompanyId);

            var branches = await _mediator.Send(new GetBranchByCompanyIdQuery { CompanyId = transactionHead.CompanyId });
            ViewBag.Branches = new SelectList(branches, "Id", "BranchName", transactionHead.BranchId);

            var accountsHeadTypes = await _mediator.Send(new GetAccountHeadTypeByCompanyIdQuery { CompanyId = transactionHead.CompanyId });
            ViewBag.AccountHeadTypes = new SelectList(accountsHeadTypes, "Id", "AccountHeadTypeName", transactionHead.AccountHeadTypeId);

            var accountsSubHeadTypes = await _mediator.Send(new GetAccountSubHeadTypeByCompanyBranchAccountsHeadTypeIdQuery { CompanyId = transactionHead.CompanyId, BranchId = transactionHead.BranchId, AccountHeadTypeId = transactionHead.AccountHeadTypeId });
            ViewBag.AccountSubHeadTypes = new SelectList(accountsSubHeadTypes, "Id", "AccountSubHeadTypeName", transactionHead.AccountSubHeadTypeId);

            return View("TransactionHeadView", transactionHead);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, [FromForm] TransactionHeadDto transactionHeadDto)
        {
            if (!ModelState.IsValid)
            {
                return View(transactionHeadDto);
            }

            var command = new UpdateTransactionHeadCommand
            {
                Id = id,
                CompanyId = transactionHeadDto.CompanyId,
                BranchId = transactionHeadDto.BranchId,
                AccountHeadTypeId = transactionHeadDto.AccountHeadTypeId,
                AccountSubHeadTypeId = transactionHeadDto.AccountSubHeadTypeId,
                TransactionHeadName = transactionHeadDto.TransactionHeadName,
                IsActive = transactionHeadDto.IsActive,
                IsDelete = true
            };

            await _mediator.Send(command);
            var alertMessage = new AlertMessage { Message = "Update has been saved!", AlertType = "success" };
            TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
            return RedirectToAction("TransactionHeadList");
        }

        // GET: TransactionHead/GetBranchesByCompanyId/{companyId}
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

        // GET: TransactionHead/GetAccountHeadTypesByCompanyId/{companyId}
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

        // GET: TransactionHead/GetAccountSubHeadTypesByCompanyBranchAccountHeadId/{companyId}
        [HttpGet]
        public async Task<IActionResult> GetAccountSubHeadTypesByCompanyBranchAccountHeadId(string companyId, string branchId, string accountHeadTypeId)
        {
            if (string.IsNullOrEmpty(companyId) || string.IsNullOrEmpty(branchId) || string.IsNullOrEmpty(accountHeadTypeId))
            {
                return Json(new { success = false, message = "Company ID, Branch ID, Account Head Type ID are required" });
            }

            var accountSubHeadTypes = await _mediator.Send(new GetAccountSubHeadTypeByCompanyBranchAccountsHeadTypeIdQuery
            {
                CompanyId = companyId,
                BranchId = branchId,
                AccountHeadTypeId = accountHeadTypeId
            });

            return Json(new { success = true, accountSubHeadTypes });
        }



        #endregion
    }
}
