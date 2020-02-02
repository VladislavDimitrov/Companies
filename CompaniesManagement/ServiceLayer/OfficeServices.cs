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
    public class OfficeServices : IOfficeServices
    {
        private readonly CompaniesDb context;
        private readonly IMapper mapper;

        public OfficeServices(CompaniesDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<OfficeDto> CreateAsync(OfficeDto officeDto)
        {
            var office = mapper.Map<Office>(officeDto);
            await context.Offices.AddAsync(office);
            await context.SaveChangesAsync();

            return officeDto;
        }

        public async Task<OfficeDto> GetAsync(int id)
        {
            var office = await context.Offices.FirstOrDefaultAsync(o => o.ID == id);
            var officeDto = mapper.Map<OfficeDto>(office);

            return officeDto;
        }

        public async Task<List<OfficeDto>> Get50Offices(int alreadyLoaded)
        {
            var offices = await context.Offices.Include(o => o.Company).Skip(alreadyLoaded).Take(50).ToListAsync();
            var officeDtos = mapper.Map<List<OfficeDto>>(offices);

            return officeDtos;
        }

        public async Task<List<OfficeDto>> GetMultipleOfficesByCompanyNameAsync(string input)
        {
            var offices = await context.Offices.Where(o => o.Company.Name.Contains(input)).Include(o => o.Employees).Include(o => o.Company).ToListAsync();
            var officeDtos = mapper.Map<List<OfficeDto>>(offices);

            return officeDtos;
        }

        public async Task UpdateAsync(OfficeDto officeDto)
        {
            var office = mapper.Map<Office>(officeDto);
            context.Offices.Update(office);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OfficeDto officeDto)
        {
            var office = mapper.Map<Office>(officeDto);
            context.Offices.Remove(office);
            await context.SaveChangesAsync();
        }
    }
}
