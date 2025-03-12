using Microsoft.EntityFrameworkCore;
using QLNhanSu2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Repositories
{
    public class PhongBanRepository : IRepository<PhongBan>
    {
        private readonly QLNhanSuContext _context;

        public PhongBanRepository(QLNhanSuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhongBan>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<PhongBan?> GetById(int id) // Cho phép null
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task Add(PhongBan entity)
        {
            _context.Departments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PhongBan entity)
        {
            _context.Departments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Departments.FindAsync(id);
            if (entity != null)
            {
                _context.Departments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}