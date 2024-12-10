using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Repository.Models.Domain;
using Repository.Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Service.Interfaces;
using Service.Services;

namespace TestTaskBuyerForm.Controllers
{
    public class BuyerFormController : Controller
    {
        private readonly IBuyerFormService _buyerFormService;

        public BuyerFormController(IBuyerFormService buyerFormService)
        {
            _buyerFormService = buyerFormService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BuyerForm buyerForm)
        {
            if (ModelState.IsValid)
            {
                await _buyerFormService.AddBuyerFormAsync(buyerForm);
                return RedirectToAction("Show");
            }
            return View(buyerForm);
        }

        [HttpGet]
        public async Task<IActionResult> Show(BuyerForm buyerForm)
        {
            var buyerFormList = await _buyerFormService.GetAllBuyerFormsAsync();
            return View(buyerFormList);
        }
    }
}
