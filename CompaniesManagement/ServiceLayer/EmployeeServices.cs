using ApplicationLayer.Utilities.DTOs;
using AutoMapper;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly CompaniesDb context;
        private readonly IMapper mapper;

        public EmployeeServices(CompaniesDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            return employeeDto;
        }

        public async Task<EmployeeDto> GetAsync(int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(e => e.ID == id);
            var employeeDto = mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public async Task<List<EmployeeDto>> GetMultipleEmployeesByNameAsync(string input)
        {
            var employees = await context.Employees.Where(e => e.FirstName.Contains(input)).Include(e => e.Company).Include(e => e.Office).ToListAsync();
            var employeeDtos = mapper.Map<List<EmployeeDto>>(employees);

            return employeeDtos;
        }

        public async Task UpdateAsync(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }
    }
}
