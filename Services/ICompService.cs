using JWTTokenAPI.Models;

namespace JWTTokenAPI.Services
{
    public interface ICompService
    {

        Task<(int, List<Company>)> CompanyList();
        Task<(int, string)> AddCompany(Company company);
        Task<(int, string)> DeleteCompany(string id);
        Task<(int, string)> UpdateCompany(Company company);
    }
}
