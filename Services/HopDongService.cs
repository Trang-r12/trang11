using QLNhanSu2025.Models;
using QLNhanSu2025.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Services
{
    public class HopDongService : IHopDongService
    {
        private readonly HopDongRepository _hopDongRepository;

        public HopDongService(HopDongRepository hopDongRepository)
        {
            _hopDongRepository = hopDongRepository;
        }

        public async Task<IEnumerable<HopDong>> GetAllHopDongs()
        {
            return await _hopDongRepository.GetAll();
        }

        public async Task<HopDong?> GetHopDongById(int id) // Cho phép null
        {
            return await _hopDongRepository.GetById(id);
        }

        public async Task AddHopDong(HopDong hopDong)
        {
            await _hopDongRepository.Add(hopDong);
        }

        public async Task UpdateHopDong(HopDong hopDong)
        {
            await _hopDongRepository.Update(hopDong);
        }

        public async Task DeleteHopDong(int id)
        {
            await _hopDongRepository.Delete(id);
        }
    }

    public interface IHopDongService
    {
        Task<IEnumerable<HopDong>> GetAllHopDongs();
        Task<HopDong?> GetHopDongById(int id); // Cho phép null
        Task AddHopDong(HopDong hopDong);
        Task UpdateHopDong(HopDong hopDong);
        Task DeleteHopDong(int id);
    }
}