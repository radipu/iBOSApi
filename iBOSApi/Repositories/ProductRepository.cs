using iBOSApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBOSApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly iBOSContext _context;
        public ProductRepository(iBOSContext context)
        {
            _context = context;
        }
        public async Task<iBOS> Create(iBOS product)
        {
            _context.tblColdDrinks.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var productToDelete = await _context.tblColdDrinks.FindAsync(id);
            _context.tblColdDrinks.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<iBOS>> Get()
        {
            _context.tblColdDrinks.RemoveRange(_context.tblColdDrinks.Where(x => x.numQuantity < 500));
            _context.SaveChanges();
            return await _context.tblColdDrinks.ToListAsync();
        }

        public async Task<iBOS> Get(int id)
        {
            return await _context.tblColdDrinks.FindAsync(id);
        }

        public async Task Update(iBOS product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
