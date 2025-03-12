using QLNhanSu2025.Models;
using QLNhanSu2025.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Services
{
    public class PhongBanService : IPhongBanService
    {
        private readonly PhongBanRepository _phongBanRepository;

        public PhongBanService(PhongBanRepository phongBanRepository)
        {
            _phongBanRepository = phongBanRepository;
        }

        public async Task<IEnumerable<PhongBan>> GetAllPhongBans()
        {
            return await _phongBanRepository.GetAll();
        }

        public async Task<PhongBan?> GetPhongBanById(int id) // Cho phép null
        {
            return await _phongBanRepository.GetById(id);
        }

        public async Task AddPhongBan(PhongBan phongBan)
        {
            await _phongBanRepository.Add(phongBan);
        }

        public async Task UpdatePhongBan(PhongBan phongBan)
        {
            await _phongBanRepository.Update(phongBan);
        }

        public async Task DeletePhongBan(int id)
        {
            await _phongBanRepository.Delete(id);
        }
    }

    public interface IPhongBanService
    {
        Task<IEnumerable<PhongBan>> GetAllPhongBans();
        Task<PhongBan?> GetPhongBanById(int id); // Cho phép null
        Task AddPhongBan(PhongBan phongBan);
        Task UpdatePhongBan(PhongBan phongBan);
        Task DeletePhongBan(int id);
    }
}