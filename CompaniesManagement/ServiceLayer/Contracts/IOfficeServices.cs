using ApplicationLayer.Utilities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IOfficeServices
    {
        Task<OfficeDto> CreateAsync(OfficeDto officeDto);
        Task<OfficeDto> GetAsync(int id);
        Task<List<OfficeDto>> Get50Offices(int alreadyLoaded);
        Task<List<OfficeDto>> GetMultipleOfficesByCompanyNameAsync(string input);
        Task UpdateAsync(OfficeDto officeDto);
        Task DeleteAsync(OfficeDto officeDto);
    }
}
