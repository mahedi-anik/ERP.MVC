using ERP.MVC.Application.Commands.FinancialYears;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Application.Queries.Company;
using ERP.MVC.Application.Queries.FinancialYears;
using ERP.MVC.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ERP.MVC.Web.Controllers
{
    public class FinancialYearController : Controller
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILogger<FinancialYearController> _logger;

        #endregion

        #region Ctor

        public FinancialYearController(IMediator mediator, ILogger<FinancialYearController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #endregion

        #region Methods

        // GET: FinancialYear/FinancialYear-List
        [HttpGet]
        public async Task<IActionResult> FinancialYearList(string search = "", int page = 1, int pageSize = 10, string sortField = "FinancialYearName", string sortOrder = "asc")
        {
            var financialYears = await _mediator.Send(new GetFinancialYearsQuery());
            var companies = await _mediator.Send(new GetCompaniesQuery());

            // Filter FinancialYears based on the search query
            var filteredFinancialYears = string.IsNullOrEmpty(search)
                ? financialYears
                : financialYears.Where(c => !string.IsNullOrEmpty(c.FinancialYearName) && c.FinancialYearName.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            // Apply sorting
            switch (sortField)
            {
                case "CompanyName":
                    filteredFinancialYears = sortOrder == "asc"
                        ? filteredFinancialYears.OrderBy(c => c.CompanyName).ToList()
                        : filteredFinancialYears.OrderByDescending(c => c.CompanyName).ToList();
                    break;
                case "FinancialYearName":
                    filteredFinancialYears = sortOrder == "asc"
                        ? filteredFinancialYears.OrderBy(c => c.FinancialYearName).ToList()
                        : filteredFinancialYears.OrderByDescending(c => c.FinancialYearName).ToList();
                    break;
                case "StartDate":
                    filteredFinancialYears = sortOrder == "asc"
                        ? filteredFinancialYears.OrderBy(c => c.StartDate).ToList()
                        : filteredFinancialYears.OrderByDescending(c => c.StartDate).ToList();
                    break;
                case "EndDate":
                    filteredFinancialYears = sortOrder == "asc"
                        ? filteredFinancialYears.OrderBy(c => c.EndDate).ToList()
                        : filteredFinancialYears.OrderByDescending(c => c.EndDate).ToList();
                    break;
                case "IsActive":
                    filteredFinancialYears = sortOrder == "asc"
                        ? filteredFinancialYears.OrderBy(c => c.IsActive).ToList()
                        : filteredFinancialYears.OrderByDescending(c => c.IsActive).ToList();
                    break;
            }

            var totalEntries = filteredFinancialYears.Count();
            var pagedFinancialYears = filteredFinancialYears.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalEntries = totalEntries;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchQuery = search;
            ViewBag.SortField = sortField;
            ViewBag.SortOrder = sortOrder;

            return View(pagedFinancialYears);
        }

        // GET: FinancialYear/FinancialYear-View
        [HttpGet]
        public async Task<IActionResult> FinancialYearView()
        {
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");
            return View(new FinancialYearDto());
        }

        //POST: FinancialYear/FinancialYear-View     
        [HttpPost]
        public async Task<IActionResult> FinancialYearView([FromForm] FinancialYearDto financialYearDto)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateFinancialYearCommand
                {
                    CompanyId = financialYearDto.CompanyId,
                    FinancialYearName = financialYearDto.FinancialYearName,
                    StartDate = financialYearDto.StartDate ?? DateTime.MinValue,
                    EndDate = financialYearDto.EndDate ?? DateTime.MinValue,
                    IsActive = financialYearDto.IsActive,
                    IsDelete = true
                };

                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    var alertMessage = new AlertMessage { Message = "New Information has been saved!", AlertType = "success" };
                    TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
                    return RedirectToAction("FinancialYearList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");

            return View(financialYearDto);
        }


        // GET: FinancialYear/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");
            var financialYear = await _mediator.Send(new GetFinancialYearByIdQuery { Id = id });
            if (financialYear == null)
                return NotFound();
            return View("FinancialYearView", financialYear);
        }

        // POST: FinancialYear/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [FromForm] FinancialYearDto financialYearDto)
        {
            if (!ModelState.IsValid)
            {
                return View(financialYearDto);
            }

            var command = new UpdateFinancialYearCommand
            {
                Id = id,
                CompanyId = financialYearDto.CompanyId,
                FinancialYearName = financialYearDto.FinancialYearName,
                StartDate = financialYearDto.StartDate ?? DateTime.MinValue,
                EndDate = financialYearDto.EndDate ?? DateTime.MinValue,
                IsActive = financialYearDto.IsActive,
                IsDelete = true
            };

            await _mediator.Send(command);
            var alertMessage = new AlertMessage { Message = "Update has been saved!", AlertType = "success" };
            TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
            return RedirectToAction("FinancialYearList");
        }




        #endregion
    }
}
