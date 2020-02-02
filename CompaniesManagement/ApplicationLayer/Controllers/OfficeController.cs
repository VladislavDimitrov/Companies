using ApplicationLayer.Models.Offices;
using ApplicationLayer.Utilities.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    public class OfficeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOfficeServices officeServices;
        private readonly ICompanyServices companyServices;

        public OfficeController(IMapper mapper, IOfficeServices officeServices, ICompanyServices companyServices)
        {
            this.mapper = mapper;
            this.officeServices = officeServices;
            this.companyServices = companyServices;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var companyDtos = await companyServices.Get50Companies(0);
            var vm = new CreateOfficeViewModel
            {
                Companies = companyDtos.Select(c => new SelectListItem(c.Name, c.ID.ToString())).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfficeViewModel vm)
        {
            var officeDto = mapper.Map<OfficeDto>(vm);
            await officeServices.CreateAsync(officeDto);

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var officeDto = await officeServices.GetAsync(id);
            var companyDtos = await companyServices.Get50Companies(0);
            var vm = mapper.Map<CreateOfficeViewModel>(officeDto);
            vm.Companies = companyDtos.Select(o => new SelectListItem(o.Name, o.ID.ToString())).ToList();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateOfficeViewModel vm)
        {
            var officeDto = mapper.Map<OfficeDto>(vm);
            await officeServices.UpdateAsync(officeDto);

            return View("Manage");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var officeDto = new OfficeDto
            {
                ID = id
            };

            try
            {
                await officeServices.DeleteAsync(officeDto);
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(string.Empty, "You cannot delete this office as there are employees assigned to it.");

                return View("Manage");

            }

            return View("Manage");
        }

        [HttpGet]
        public IActionResult Manage()
        {
            return View();
        }

        public async Task<IActionResult> Manage(ManageOfficesViewModel vm)
        {
            var officeDtos = await officeServices.GetMultipleOfficesByCompanyNameAsync(vm.Input);
            if (officeDtos.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No offices found with this company name.");

                return View();
            }

            vm.Offices = mapper.Map<List<OfficeViewModel>>(officeDtos);

            return View(vm);
        }
    }
}