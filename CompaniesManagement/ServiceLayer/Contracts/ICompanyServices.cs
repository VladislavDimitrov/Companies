using ApplicationLayer.Utilities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface ICompanyServices
    {
        Task<CompanyDto> CreateAsync(CompanyDto companyDto);
        Task<CompanyDto> GetAsync(int id);
        Task<CompanyDto> GetCompanyByOfficeID(int id);
        Task<List<CompanyDto>> GetMultipleCompaniesByNameAsync(string input);
        Task<List<CompanyDto>> Get50Companies(int alreadyLoaded);
        Task UpdateAsync(CompanyDto companyDto);
        Task DeleteAsync(CompanyDto companyDto);
    }
}
