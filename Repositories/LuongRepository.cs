using Microsoft.EntityFrameworkCore;
using QLNhanSu2025.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Repositories
{
    public class LuongRepository : IRepository<Luong>
    {
        private readonly QLNhanSuContext _context; // Đã sửa tên Context Class

        public LuongRepository(QLNhanSuContext context) // Đã sửa tên Context Class
        {
            _context = context;
        }

        public async Task<IEnumerable<Luong>> GetAll()
        {
            return await _context.Salaries.ToListAsync(); //Đã sửa ở đây
        }

        public async Task<Luong?> GetById(int id) // Cho phép null
        {
            return await _context.Salaries.FindAsync(id); //Đã sửa ở đây
        }


        public async Task Add(Luong entity)
        {
            _context.Salaries.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Luong entity)
        {
            _context.Salaries.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Salaries.FindAsync(id);

            if (entity == null)
            {
                // Xử lý trường hợp không tìm thấy entity.
                // Bạn có thể ném một ngoại lệ, ghi log, hoặc trả về false để báo hiệu việc xóa thất bại.
                // Ví dụ:
                // throw new Exception($"Không tìm thấy bản ghi Salary với ID: {id}");
                // hoặc
                Console.WriteLine($"Không tìm thấy bản ghi Salary với ID: {id}"); // Ghi log
                return; // Kết thúc hàm Delete
            }

            _context.Salaries.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}