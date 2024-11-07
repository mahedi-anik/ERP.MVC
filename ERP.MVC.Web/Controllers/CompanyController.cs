using ERP.MVC.Application.Commands.Companies;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Application.Queries.Company;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.MVC.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(IMediator mediator, ILogger<CompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET: Company/Company-List
        [HttpGet]
        public async Task<IActionResult> CompanyList()
        {
            var companies = await _mediator.Send(new GetCompaniesQuery());
            return View(companies);
        }

        // GET: Company/Company-View
        [HttpGet]
        public IActionResult CompanyView()
        {
            return View(new CompanyDto());
        }

        // POST: Company/Company-View
        [HttpPost]
        public async Task<IActionResult> CompanyView([FromForm] CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateCompanyCommand
                {
                    CompanyName = companyDto.CompanyName,
                    MobileNo = companyDto.MobileNo,
                    Email = companyDto.Email,
                    Address = companyDto.Address,
                    IsActive = companyDto.IsActive,
                    ImageURL = companyDto.ImageURL
                };
                var companyId = await _mediator.Send(command);
                return RedirectToAction("CompanyList");
            }

            return View(companyDto);
        }

        // GET: Company/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var company = await _mediator.Send(new GetCompanyByIdQuery { Id = id });
            if (company == null) return NotFound();

            return View(company);
        }

        // POST: Company/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [FromForm] CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateCompanyCommand
                {
                    CompanyName = companyDto.CompanyName,
                    MobileNo = companyDto.MobileNo,
                    Email = companyDto.Email,
                    Address = companyDto.Address,
                    IsActive = companyDto.IsActive,
                    ImageURL = companyDto.ImageURL
                };
                await _mediator.Send(command);
                return RedirectToAction("CompanyList");
            }

            return View(companyDto);
        }

        // GET: Company/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var company = await _mediator.Send(new GetCompanyByIdQuery { Id = id });
            if (company == null) return NotFound();

            return View(company);
        }

        // POST: Company/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _mediator.Send(new DeleteCompanyCommand { Id = id });
            return RedirectToAction("CompanyList");
        }
    }


}