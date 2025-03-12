using Microsoft.EntityFrameworkCore;
using QLNhanSu2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Repositories
{
    public class NgayNghiRepository : IRepository<NgayNghi>
    {
        private readonly QLNhanSuContext _context;

        public NgayNghiRepository(QLNhanSuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NgayNghi>> GetAll()
        {
            return await _context.Leaves.ToListAsync();
        }

        public async Task<NgayNghi?> GetById(int id) // Cho phép null
        {
            return await _context.Leaves.FindAsync(id);
        }

        public async Task Add(NgayNghi entity)
        {
            _context.Leaves.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(NgayNghi entity)
        {
            _context.Leaves.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Leaves.FindAsync(id);
            if (entity != null)
            {
                _context.Leaves.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}