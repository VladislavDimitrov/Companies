using ApplicationLayer.Utilities.DTOs;
using AutoMapper;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class CompanyServices : ICompanyServices
    {
        private readonly CompaniesDb context;
        private readonly IMapper mapper;

        public CompanyServices(CompaniesDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<CompanyDto> CreateAsync(CompanyDto companyDto)
        {
            var company = mapper.Map<Company>(companyDto);
            await context.Companies.AddAsync(company);
            await context.SaveChangesAsync();

            return companyDto;
        }

        public async Task DeleteAsync(CompanyDto companyDto)
        {
            var company = mapper.Map<Company>(companyDto);
            context.Companies.Remove(company);
            await context.SaveChangesAsync();
        }

        public async Task<CompanyDto> GetAsync(int id)
        {
            var company = await context.Companies.FirstOrDefaultAsync(c => c.ID == id);
            var companyDto = mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        public async Task<List<CompanyDto>> GetMultipleCompaniesByNameAsync(string input)
        {
            var companies = await context.Companies.Where(c => c.Name.Contains(input)).Include(c => c.Offices).Include(c => c.Employees).ToListAsync();
            var companyDtos = mapper.Map<List<CompanyDto>>(companies);

            return companyDtos;
        }

        public async Task<List<CompanyDto>> Get50Companies(int alreadyLoaded)
        {
            var companies = await context.Companies.Skip(alreadyLoaded).Take(50).ToListAsync();
            var companyDtos = mapper.Map<List<CompanyDto>>(companies);

            return companyDtos;
        }

        public async Task<CompanyDto> GetCompanyByOfficeID(int id)
        {
            var companies = await context.Companies.Include(c => c.Offices).FirstOrDefaultAsync(c => c.Offices.Any(o => o.ID == id));
            var companyDtos = mapper.Map<CompanyDto>(companies);

            return companyDtos;
        }

        public async Task UpdateAsync(CompanyDto companyDto)
        {
            var company = mapper.Map<Company>(companyDto);
            context.Companies.Update(company);
            await context.SaveChangesAsync();
        }
    }
}
