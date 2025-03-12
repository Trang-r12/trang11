using QLNhanSu2025.Models;
using QLNhanSu2025.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Services
{
    public class NhanVienService : INhanVienService
    {
        private readonly NhanVienRepository _nhanVienRepository;

        public NhanVienService(NhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<IEnumerable<NhanVien>> GetAllNhanViens()
        {
            return await _nhanVienRepository.GetAll();
        }

        public async Task<NhanVien?> GetNhanVienById(int id) // Cho phép null
        {
            return await _nhanVienRepository.GetById(id);
        }

        public async Task AddNhanVien(NhanVien nhanVien)
        {
            await _nhanVienRepository.Add(nhanVien);
        }

        public async Task UpdateNhanVien(NhanVien nhanVien)
        {
            await _nhanVienRepository.Update(nhanVien);
        }

        public async Task DeleteNhanVien(int id)
        {
            await _nhanVienRepository.Delete(id);
        }
    }

    public interface INhanVienService
    {
        Task<IEnumerable<NhanVien>> GetAllNhanViens();
        Task<NhanVien?> GetNhanVienById(int id); // Cho phép null
        Task AddNhanVien(NhanVien nhanVien);
        Task UpdateNhanVien(NhanVien nhanVien);
        Task DeleteNhanVien(int id);
    }
}