using ApplicationLayer.Utilities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IEmployeeServices
    {
        Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto);
        Task<EmployeeDto> GetAsync(int id);
        Task<List<EmployeeDto>> GetMultipleEmployeesByNameAsync(string input);
        Task UpdateAsync(EmployeeDto employeeDto);
        Task DeleteAsync(EmployeeDto employeeDto);
    }
}
