using Microsoft.EntityFrameworkCore;
using QLNhanSu2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Repositories
{
    public class NguoiDungRepository : IRepository<NguoiDung>
    {
        private readonly QuanLyNhanSuContext _context;

        public NguoiDungRepository(QuanLyNhanSuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NguoiDung>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<NguoiDung?> GetById(int id) // Cho phép null
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Add(NguoiDung entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(NguoiDung entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity != null)
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}