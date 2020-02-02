using ApplicationLayer.Models.Employees;
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
    public class EmployeeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEmployeeServices employeeServices;
        private readonly IOfficeServices officeServices;
        private readonly ICompanyServices companyServices;

        public EmployeeController(IMapper mapper, IEmployeeServices employeeServices, IOfficeServices officeServices, ICompanyServices companyServices)
        {
            this.mapper = mapper;
            this.employeeServices = employeeServices;
            this.officeServices = officeServices;
            this.companyServices = companyServices;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var offices = await officeServices.Get50Offices(0);
            var vm = new CreateEmployeeViewModel
            {
                Offices = offices.Select(o => new SelectListItem($"Company: {o.Company.Name} / Office: {o.City},{o.Street}", o.ID.ToString())).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel vm)
        {
            var company = await companyServices.GetCompanyByOfficeID(vm.OfficeID);
            var employeeDto = mapper.Map<EmployeeDto>(vm);
            employeeDto.CompanyID = company.ID;
            await employeeServices.CreateAsync(employeeDto);

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var employeeDto = await employeeServices.GetAsync(id);
            var offices = await officeServices.Get50Offices(0);
            var vm = mapper.Map<CreateEmployeeViewModel>(employeeDto);
            vm.Offices = offices.Select(o => new SelectListItem($"Company: {o.Company.Name} / Office: {o.City},{o.Street}", o.ID.ToString())).ToList();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateEmployeeViewModel vm)
        {
            var employeeDto = mapper.Map<EmployeeDto>(vm);
            await employeeServices.UpdateAsync(employeeDto);

            return View("Manage");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employeeDto = new EmployeeDto
            {
                ID = id
            };

            await employeeServices.DeleteAsync(employeeDto);

            return View("Manage");
        }

        [HttpGet]
        public IActionResult Manage()
        {
            return View();
        }

        public async Task<IActionResult> Manage(ManageEmployeesViewModel vm)
        {
            var employeeDtos = await employeeServices.GetMultipleEmployeesByNameAsync(vm.Input);
            if (employeeDtos.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No employees found with this name.");

                return View();
            }

            vm.Employees = mapper.Map<List<EmployeeViewModel>>(employeeDtos);

            return View(vm);
        }
    }
}