using Microsoft.EntityFrameworkCore;
using QLNhanSu2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Repositories
{
    public class HopDongRepository : IRepository<HopDong>
    {
        private readonly QuanLyNhanSuContext _context;

        public HopDongRepository(QuanLyNhanSuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HopDong>> GetAll()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task<HopDong?> GetById(int id) // Cho phép null
        {
            return await _context.Contracts.FindAsync(id);
        }

        public async Task Add(HopDong entity)
        {
            _context.Contracts.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(HopDong entity)
        {
            _context.Contracts.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Contracts.FindAsync(id);
            if (entity != null)
            {
                _context.Contracts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}