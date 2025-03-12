using Microsoft.EntityFrameworkCore;
using QLNhanSu2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Repositories
{
    public class ViTriRepository : IRepository<ViTri>
    {
        private readonly QLNhanSuContext _context;

        public ViTriRepository(QLNhanSuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ViTri>> GetAll()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<ViTri?> GetById(int id) // Cho phép null
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task Add(ViTri entity)
        {
            _context.Positions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ViTri entity)
        {
            _context.Positions.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Positions.FindAsync(id);
            if (entity != null)
            {
                _context.Positions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}