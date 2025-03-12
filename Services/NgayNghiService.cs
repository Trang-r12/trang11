using QLNhanSu2025.Models;
using QLNhanSu2025.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Services
{
    public class NgayNghiService : INgayNghiService
    {
        private readonly NgayNghiRepository _ngayNghiRepository;

        public NgayNghiService(NgayNghiRepository ngayNghiRepository)
        {
            _ngayNghiRepository = ngayNghiRepository;
        }

        public async Task<IEnumerable<NgayNghi>> GetAllNgayNghis()
        {
            return await _ngayNghiRepository.GetAll();
        }

        public async Task<NgayNghi?> GetNgayNghiById(int id) // Cho phép null
        {
            return await _ngayNghiRepository.GetById(id);
        }

        public async Task AddNgayNghi(NgayNghi ngayNghi)
        {
            await _ngayNghiRepository.Add(ngayNghi);
        }

        public async Task UpdateNgayNghi(NgayNghi ngayNghi)
        {
            await _ngayNghiRepository.Update(ngayNghi);
        }

        public async Task DeleteNgayNghi(int id)
        {
            await _ngayNghiRepository.Delete(id);
        }
    }

    public interface INgayNghiService
    {
        Task<IEnumerable<NgayNghi>> GetAllNgayNghis();
        Task<NgayNghi?> GetNgayNghiById(int id); // Cho phép null
        Task AddNgayNghi(NgayNghi ngayNghi);
        Task UpdateNgayNghi(NgayNghi ngayNghi);
        Task DeleteNgayNghi(int id);
    }
}