using ApplicationLayer.Models.Companies;
using ApplicationLayer.Utilities.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICompanyServices companyServices;

        public CompanyController(IMapper mapper, ICompanyServices companyServices)
        {
            this.mapper = mapper;
            this.companyServices = companyServices;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyViewModel vm)
        {
            var companyDto = mapper.Map<CompanyDto>(vm);
            await companyServices.CreateAsync(companyDto);

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var companyDto = await companyServices.GetAsync(id);
            var vm = mapper.Map<CompanyViewModel>(companyDto);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyViewModel vm)
        {
            var companyDto = mapper.Map<CompanyDto>(vm);
            await companyServices.UpdateAsync(companyDto);

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var companyDto = new CompanyDto
            {
                ID = id
            };

            try
            {
                await companyServices.DeleteAsync(companyDto);
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "You cannot delete this company yet. Please delete the company's offices first.");

                return View("Manage");
            }

            return View("Manage");
        }

        [HttpGet]
        public IActionResult Manage()
        {
            return View();
        }

        public async Task<IActionResult> Manage(ManageCompaniesViewModel vm)
        {
            var companyDtos = await companyServices.GetMultipleCompaniesByNameAsync(vm.Input);
            if (companyDtos.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No companies found with this name.");

                return View();
            }

            vm.Companies = mapper.Map<List<CompanyViewModel>>(companyDtos);

            return View(vm);
        }
    }
}