﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Transfermarkt_Core.Contracts;
using My_Transfermarkt_Core.Models.CountryModels;

namespace My_Transfermarkt.Areas.Administrator.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CountryController : BaseController
    {
        private readonly ICountryService countryService;

        public CountryController(
            ICountryService _countryServ)
        {
            countryService = _countryServ;
        }
        [HttpGet]
        public IActionResult AddNewCountry()
        {
            AddNewCountryModel model  = new AddNewCountryModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCountry(AddNewCountryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var isThereAlready = await countryService.IsAlreadyCreated(model);
            if (isThereAlready == true)
            {
                ViewBag.Comment = "Country Already Exist";
                return View(model);
            }
            await countryService.AddCountryAsync(model);

            return RedirectToAction(nameof(AllCountries));
        }

        public async Task<IActionResult> AllCountries()
        {
            var displayResult =  await countryService.AllCountriesAsync();
            return View(displayResult);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            AddNewCountryModel model = await countryService.FindCountry(id);
            if (model == null)
            {
                return View("Error404", new { area = "" });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddNewCountryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var isThereAlready = await countryService.IsAlreadyCreated(model);
            if (isThereAlready == true)
            {
                ViewBag.Comment = "Country Already Exist";
                return View(model);
            }

            await countryService.SaveChangesAsync(model);

            return RedirectToAction(nameof(AllCountries));
        }
    }
}
