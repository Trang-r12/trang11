using Microsoft.EntityFrameworkCore;
using QLNhanSu2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Repositories
{
    public class NhanVienRepository : IRepository<NhanVien> // Thêm interface ở đây
    {
        private readonly QLNhanSuContext _context;

        public NhanVienRepository(QLNhanSuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NhanVien>> GetAll()
        {
            return await _context.NhanViens.ToListAsync();
        }

        public async Task<NhanVien?> GetById(int id)
        {
            return await _context.NhanViens.FindAsync(id);
        }

        public async Task Add(NhanVien entity)
        {
            _context.NhanViens.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(NhanVien entity)
        {
            _context.NhanViens.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.NhanViens.FindAsync(id);
            if (entity != null)
            {
                _context.NhanViens.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}