using JWTTokenAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTTokenAPI.Data;
using JWTTokenAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTTokenAPI.Services
{
    public class CompService : ICompService
    {
        private readonly JWTTokenAPIContext _context;

        public CompService(JWTTokenAPIContext context)
        {
            _context = context;
        }
        public async Task<(int, string)> AddCompany(Company company)
        {
            if (_context.Company == null)
            {
                return (0, "Not OK");
            }
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
            return (1,"Ok");
        }  
        
        public async Task<(int, string)> UpdateCompany(Company company)
        {
            if (_context.Company == null)
            {
                return (0, "Not OK");
            }

            var id= company.Id;
                if (id != company.Id)
                {
                return (0, "Not OK");
            }

                _context.Entry(company).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(id))
                    {
                    return (0, "Not OK");
                }
                    else
                    {
                        throw;
                    }
                }

           return (1, "OK");


           
        }

        public async Task<(int, List<Company>)> CompanyList()
        {
            if (_context.Company == null)
            {
                return (0, new List<Company>());
            }
            var userList = await( _context.Company.ToListAsync());
            return (1, userList);
        }

        public async Task<(int, string)> DeleteCompany(string id)
        {
            if (_context.Company == null)
            {
                 return (0, "Not OK");
            }
            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return (0, "Not OK");
            }

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return (1, "Not OK");
        }

        private bool CompanyExists(int id)
        {
            return (_context.Company?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
