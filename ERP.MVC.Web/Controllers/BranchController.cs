using ERP.MVC.Application.Commands.Branches;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Application.Queries.Branches;
using ERP.MVC.Application.Queries.Company;
using ERP.MVC.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ERP.MVC.Web.Controllers
{
    public class BranchController : Controller
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILogger<BranchController> _logger;

        #endregion

        #region Ctor

        public BranchController(IMediator mediator, ILogger<BranchController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #endregion

        #region Methods

        // GET: Branch/Branch-List
        [HttpGet]
        public async Task<IActionResult> BranchList(string search = "", int page = 1, int pageSize = 10, string sortField = "BranchName", string sortOrder = "asc")
        {
            var branches = await _mediator.Send(new GetBranchesQuery());
            var companies = await _mediator.Send(new GetCompaniesQuery()); 

            // Filter branches based on the search query
            var filteredBranches = string.IsNullOrEmpty(search)
                ? branches
                : branches.Where(c => !string.IsNullOrEmpty(c.BranchName) && c.BranchName.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            // Apply sorting
            switch (sortField)
            {
                case "CompanyName":
                    filteredBranches = sortOrder == "asc"
                        ? filteredBranches.OrderBy(c => c.CompanyName).ToList()
                        : filteredBranches.OrderByDescending(c => c.CompanyName).ToList();
                    break;
                case "BranchName":
                    filteredBranches = sortOrder == "asc"
                        ? filteredBranches.OrderBy(c => c.BranchName).ToList()
                        : filteredBranches.OrderByDescending(c => c.BranchName).ToList();
                    break;
                case "MobileNo":
                    filteredBranches = sortOrder == "asc"
                        ? filteredBranches.OrderBy(c => c.MobileNo).ToList()
                        : filteredBranches.OrderByDescending(c => c.MobileNo).ToList();
                    break;
                case "Email":
                    filteredBranches = sortOrder == "asc"
                        ? filteredBranches.OrderBy(c => c.Email).ToList()
                        : filteredBranches.OrderByDescending(c => c.Email).ToList();
                    break;
                case "Address":
                    filteredBranches = sortOrder == "asc"
                        ? filteredBranches.OrderBy(c => c.Address).ToList()
                        : filteredBranches.OrderByDescending(c => c.Address).ToList();
                    break;
                case "IsActive":
                    filteredBranches = sortOrder == "asc"
                        ? filteredBranches.OrderBy(c => c.IsActive).ToList()
                        : filteredBranches.OrderByDescending(c => c.IsActive).ToList();
                    break;
            }

            var totalEntries = filteredBranches.Count();
            var pagedBranches = filteredBranches.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalEntries = totalEntries;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchQuery = search;
            ViewBag.SortField = sortField;
            ViewBag.SortOrder = sortOrder;

            return View(pagedBranches);
        }

        // GET: Branch/Branch-View
        [HttpGet]
        public async Task<IActionResult> BranchView()
        {
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName"); 
            return View(new BranchDto());
        }

        //POST: Branch/Branch-View     
        [HttpPost]
        public async Task<IActionResult> BranchView([FromForm] BranchDto branchDto)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateBranchCommand
                {
                    CompanyId = branchDto.CompanyId,
                    BranchName = branchDto.BranchName,
                    MobileNo = branchDto.MobileNo,
                    TelephoneNo = branchDto.TelephoneNo,
                    Email = branchDto.Email,
                    Address = branchDto.Address,
                    IsActive = branchDto.IsActive,
                    IsDelete = true
                };

                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    var alertMessage = new AlertMessage { Message = "New Information has been saved!", AlertType = "success" };
                    TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
                    return RedirectToAction("BranchList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");

            return View(branchDto);
        }


        // GET: Branch/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var companies = await _mediator.Send(new GetCompaniesQuery());
            ViewBag.Companies = new SelectList(companies, "Id", "CompanyName");
            var branch = await _mediator.Send(new GetBranchByIdQuery { Id = id });
            if (branch == null)
                return NotFound();
            return View("BranchView", branch);
        }

        // POST: Branch/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [FromForm] BranchDto branchDto)
        {
            if (!ModelState.IsValid)
            {
                return View(branchDto);
            }

            var command = new UpdateBranchCommand
            {
                Id = id,
                CompanyId = branchDto.CompanyId,
                BranchName = branchDto.BranchName,
                MobileNo = branchDto.MobileNo,
                TelephoneNo = branchDto.TelephoneNo,
                Email = branchDto.Email,
                Address = branchDto.Address,
                IsActive = branchDto.IsActive,
                IsDelete = true
            };

            await _mediator.Send(command);
            var alertMessage = new AlertMessage { Message = "Update has been saved!", AlertType = "success" };
            TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
            return RedirectToAction("BranchList");
        }

        /// GET: Branch/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var branch = await _mediator.Send(new GetBranchByIdQuery { Id = id });
            if (branch == null) return NotFound();

            await _mediator.Send(new DeleteBranchCommand { Id = id });
            var alertMessage = new AlertMessage { Message = "This is a danger alert — Id was deleted!", AlertType = "danger" };
            TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
            return RedirectToAction("BranchList");
        }

        // POST: Branch/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _mediator.Send(new DeleteBranchCommand { Id = id });
            return RedirectToAction("BranchList");
        }


        #endregion
    }
}
