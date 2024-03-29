﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWTTokenAPI.Data;
using JWTTokenAPI.Models;
using JWTTokenAPI.Models;
using JWTTokenAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JWTTokenAPI.Models;
using JWTTokenAPI.Services;

namespace JWTTokenAPI.Controllers
{
    [Route("api/Companies")]
    [ApiController]
    [Authorize]

    public class CompaniesController : ControllerBase
    {
        private readonly JWTTokenAPIContext _context;
        private readonly ICompService _compService;
        private readonly ILogger<AuthenticationController> _logger;

        public CompaniesController(ICompService compService,JWTTokenAPIContext context, ILogger<AuthenticationController> logger)
        {
         
            _context = context;
            _compService = compService;
            _logger = logger;
        }

        //GET: api/Companies
       [HttpGet]
       
        public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
        {
            if (_context.Company == null)
            {
                return NotFound();
            }
            return await _context.Company.ToListAsync();
        }

        //[HttpGet]
      
        //public async Task<IActionResult> Get()
        //{
        //    var (status, message) = await _compService.CompanyList();
        //    return Ok(message);
        //}


        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            if (_context.Company == null)
            {
                return NotFound();
            }
            var company = await _context.Company.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            if (_context.Company == null)
            {
                return Problem("Entity set 'JWTTokenAPIContext.Company'  is null.");
            }
            _context.Company.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            if (_context.Company == null)
            {
                return NotFound();
            }
            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return (_context.Company?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
