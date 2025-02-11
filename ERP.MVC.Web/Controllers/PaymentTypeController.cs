using ERP.MVC.Application.Commands.PaymentTypes;
using ERP.MVC.Application.DTOs;
using ERP.MVC.Application.Queries.PaymentTypes;
using ERP.MVC.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ERP.MVC.Web.Controllers
{
    public class PaymentTypeController : Controller
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILogger<PaymentTypeController> _logger;

        #endregion

        #region Ctor

        public PaymentTypeController(IMediator mediator, ILogger<PaymentTypeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #endregion

        #region Methods

        // GET: PaymentType/PaymentType-List
        [HttpGet]
        public async Task<IActionResult> PaymentTypeList(string search = "", int page = 1, int pageSize = 10, string sortField = "PaymentTypeName", string sortOrder = "asc")
        {
            var paymentTypes = await _mediator.Send(new GetPaymentTypesQuery());

            // Filter PaymentTypess based on the search query
            var filteredPaymentTypes = string.IsNullOrEmpty(search)
                ? paymentTypes
                : paymentTypes.Where(c => !string.IsNullOrEmpty(c.PaymentTypeName) && c.PaymentTypeName.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            // Apply sorting
            switch (sortField)
            {
                case "PaymentTypeName":
                    filteredPaymentTypes = sortOrder == "asc"
                        ? filteredPaymentTypes.OrderBy(c => c.PaymentTypeName).ToList()
                        : filteredPaymentTypes.OrderByDescending(c => c.PaymentTypeName).ToList();
                    break;
                case "Remarks":
                    filteredPaymentTypes = sortOrder == "asc"
                        ? filteredPaymentTypes.OrderBy(c => c.Remarks).ToList()
                        : filteredPaymentTypes.OrderByDescending(c => c.Remarks).ToList();
                    break;
                case "IsActive":
                    filteredPaymentTypes = sortOrder == "asc"
                        ? filteredPaymentTypes.OrderBy(c => c.IsActive).ToList()
                        : filteredPaymentTypes.OrderByDescending(c => c.IsActive).ToList();
                    break;
            }

            var totalEntries = filteredPaymentTypes.Count();
            var pagedPaymetTypes = filteredPaymentTypes.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalEntries = totalEntries;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchQuery = search;
            ViewBag.SortField = sortField;
            ViewBag.SortOrder = sortOrder;

            return View(pagedPaymetTypes);
        }

        // GET: PaymentType/PaymentType-View
        [HttpGet]
        public async Task<IActionResult> PaymentTypeView()
        {
            return View(new PaymentTypeDto());
        }

        //POST: PaymentType/PaymentType-View     
        [HttpPost]
        public async Task<IActionResult> PaymentTypeView([FromForm] PaymentTypeDto paymentTypeDto)
        {
            if (ModelState.IsValid)
            {
                var command = new CreatePaymentTypeCommand
                {
                    PaymentTypeName = paymentTypeDto.PaymentTypeName,
                    Remarks = paymentTypeDto.Remarks,
                    IsActive = paymentTypeDto.IsActive,
                    IsDelete = true
                };

                var result = await _mediator.Send(command);

                if (result.IsSuccess)
                {
                    var alertMessage = new AlertMessage { Message = "New Information has been saved!", AlertType = "success" };
                    TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
                    return RedirectToAction("PaymentTypeList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return View(paymentTypeDto);
        }


        // GET: PaymentType/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var paymentType = await _mediator.Send(new GetPaymentTypeByIdQuery { Id = id });
            if (paymentType == null)
                return NotFound();
            return View("PaymentTypeView", paymentType);
        }

        // POST: PaymentType/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [FromForm] PaymentTypeDto paymentTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(paymentTypeDto);
            }

            var command = new UpdatePaymentTypeCommand
            {
                Id = id,
                PaymentTypeName = paymentTypeDto.PaymentTypeName,
                Remarks = paymentTypeDto.Remarks,
                IsActive = paymentTypeDto.IsActive,
                IsDelete = true
            };

            await _mediator.Send(command);
            var alertMessage = new AlertMessage { Message = "Update has been saved!", AlertType = "success" };
            TempData["AlertMessage"] = JsonConvert.SerializeObject(alertMessage);
            return RedirectToAction("PaymentTypeList");
        }




        #endregion
    }
}
