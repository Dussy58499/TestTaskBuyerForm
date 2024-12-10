using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Repository.Interfaces;
using Repository.Data;
using Repository.Models.Domain;

namespace Repository.Repository
{
    public class BuyerFormRepository : IBuyerFormRepository
    {
        private readonly AppDbContext _context;

        public BuyerFormRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException DbEx)
            {
                throw new Exception("Database update failed", DbEx);
            }
            catch (Exception ex) 
            {
                throw new Exception("An error while saving database", ex);
            }
        }

        public async Task AddAsync(BuyerForm entity)
        {
            try
            {
                await _context.BuyerForms.AddAsync(entity);
            }
            catch (Exception ex) 
            {
                throw new Exception("An error while adding a new buyer", ex);
            }
        }

        public async Task<IEnumerable<BuyerForm>> GetAllAsync()
        {
            try
            {
                return await _context.BuyerForms.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error while fetching buyer forms");
            }
        }
    }
}
