using QLNhanSu2025.Models;
using QLNhanSu2025.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Services
{
    public class ChamCongService : IChamCongService
    {
        private readonly ChamCongRepository _chamCongRepository;

        public ChamCongService(ChamCongRepository chamCongRepository)
        {
            _chamCongRepository = chamCongRepository;
        }

        public async Task<IEnumerable<ChamCong>> GetAllChamCongs()
        {
            return await _chamCongRepository.GetAll();
        }

        public async Task<ChamCong?> GetChamCongById(int id) // Cho phép null
        {
            return await _chamCongRepository.GetById(id);
        }

        public async Task AddChamCong(ChamCong chamCong)
        {
            await _chamCongRepository.Add(chamCong);
        }

        public async Task UpdateChamCong(ChamCong chamCong)
        {
            await _chamCongRepository.Update(chamCong);
        }

        public async Task DeleteChamCong(int id)
        {
            await _chamCongRepository.Delete(id);
        }
    }

    public interface IChamCongService
    {
        Task<IEnumerable<ChamCong>> GetAllChamCongs();
        Task<ChamCong?> GetChamCongById(int id); // Cho phép null
        Task AddChamCong(ChamCong chamCong);
        Task UpdateChamCong(ChamCong chamCong);
        Task DeleteChamCong(int id);
    }
}