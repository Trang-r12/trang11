using Microsoft.EntityFrameworkCore;
using QLNhanSu2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Repositories
{
    public class ChamCongRepository : IRepository<ChamCong>
    {
        private readonly QuanLyNhanSuContext _context;

        public ChamCongRepository(QuanLyNhanSuContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChamCong>> GetAll()
        {
            return await _context.Attendances.ToListAsync(); // Lưu ý: Attendances phải khớp với tên DbSet
        }

        public async Task<ChamCong?> GetById(int id) // Cho phép null
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task Add(ChamCong entity)
        {
            try
            {
                _context.Attendances.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ví dụ: log lỗi)
                Console.WriteLine($"Error adding ChamCong: {ex.Message}");
                throw; // Re-throw exception để báo cho caller
            }
        }

        public async Task Update(ChamCong entity)
        {
            try
            {
                var existingEntity = await _context.Attendances.FindAsync(entity.MaChamCong); // Tìm theo khóa chính (MaChamCong)

                if (existingEntity != null)
                {
                    _context.Entry(existingEntity).CurrentValues.SetValues(entity); // Cập nhật các giá trị
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Xử lý trường hợp entity không tồn tại (ném exception, log, ...)
                    throw new Exception("ChamCong not found");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine($"Error updating ChamCong: {ex.Message}");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await _context.Attendances.FindAsync(id);
                if (entity != null)
                {
                    _context.Attendances.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Xử lý trường hợp entity không tồn tại
                    throw new Exception("ChamCong not found");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine($"Error deleting ChamCong: {ex.Message}");
                throw;
            }
        }
    }
}