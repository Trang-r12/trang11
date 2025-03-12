using QLNhanSu2025.Models;
using QLNhanSu2025.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Services
{
    public class LuongService : ILuongService
    {
        private readonly LuongRepository _luongRepository;

        public LuongService(LuongRepository luongRepository)
        {
            _luongRepository = luongRepository;
        }

        public async Task<IEnumerable<Luong>> GetAllLuongs()
        {
            return await _luongRepository.GetAll();
        }

        public async Task<Luong?> GetLuongById(int id) // Cho phép null
        {
            return await _luongRepository.GetById(id);
        }

        public async Task AddLuong(Luong luong)
        {
            await _luongRepository.Add(luong);
        }

        public async Task UpdateLuong(Luong luong)
        {
            await _luongRepository.Update(luong);
        }

        public async Task DeleteLuong(int id)
        {
            await _luongRepository.Delete(id);
        }
    }

    public interface ILuongService
    {
        Task<IEnumerable<Luong>> GetAllLuongs();
        Task<Luong?> GetLuongById(int id); // Cho phép null
        Task AddLuong(Luong luong);
        Task UpdateLuong(Luong luong);
        Task DeleteLuong(int id);
    }
}