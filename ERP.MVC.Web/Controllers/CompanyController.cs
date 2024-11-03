using ERP.MVC.Application.Commands.Companies;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
        {
            var companyId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = companyId }, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _mediator.Send(new GetCompaniesQuery());
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var company = await _mediator.Send(new GetCompanyByIdQuery { Id = id });
            return company != null ? Ok(company) : NotFound();
        }
    }
}