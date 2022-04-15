﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartFarm.Data.Entities;
using SmartFarm.Models;
using SmartFarm.Services;

namespace SmartFarm.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInputService _inputService;
        private readonly IOutputService _outputservice;
        private readonly ICustomerService _customerService;
        private readonly IChartContext _chartContext;

        public StatisticController(ILogger<HomeController> logger,IInputService inputService, ICustomerService customerService, IChartContext chartContext)
        private readonly UserManager<Customer> _userManager;

        public StatisticController(ILogger<HomeController> logger,IInputService inputService, ICustomerService customerService,IOutputService outputService, UserManager<Customer> userManager)
        {
            _logger = logger;
            _inputService = inputService;
            _customerService = customerService;
            _chartContext = chartContext;
            _outputservice = outputService;
            _userManager = userManager;
        }
        public async Task<IActionResult> ThonkeAsync(int idFarm)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            //var input=await _inputService.GetInputsAsync();
            //InputAndOutputModel result=new InputAndOutputModel();
            //result.Inputs=input;
            //return View(result);
            idFarm = _userManager.GetUserAsync(User).Result.SoHuuTrangTrai;
            var equipment = await _customerService.GetEquipmentAsync(idFarm);
            return View(equipment);
        }
        [HttpGet]
        public async Task<IActionResult> InputAsync(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var input=await _inputService.GetInputIdAsync(id);
            return View(input);
        }

        [HttpGet]
        public IActionResult Output(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Home");
            }
            var result = _outputservice.GetOutputById(id);
            return View(result);
        }
    }
}
