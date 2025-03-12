using QLNhanSu2025.Models;
using QLNhanSu2025.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNhanSu2025.Services
{
    public class ViTriService : IViTriService
    {
        private readonly ViTriRepository _viTriRepository;

        public ViTriService(ViTriRepository viTriRepository)
        {
            _viTriRepository = viTriRepository;
        }

        public async Task<IEnumerable<ViTri>> GetAllViTris()
        {
            return await _viTriRepository.GetAll();
        }

        public async Task<ViTri?> GetViTriById(int id) // Cho phép null
        {
            return await _viTriRepository.GetById(id);
        }

        public async Task AddViTri(ViTri viTri)
        {
            await _viTriRepository.Add(viTri);
        }

        public async Task UpdateViTri(ViTri viTri)
        {
            await _viTriRepository.Update(viTri);
        }

        public async Task DeleteViTri(int id)
        {
            await _viTriRepository.Delete(id);
        }
    }

    public interface IViTriService
    {
        Task<IEnumerable<ViTri>> GetAllViTris();
        Task<ViTri?> GetViTriById(int id); // Cho phép null
        Task AddViTri(ViTri viTri);
        Task UpdateViTri(ViTri viTri);
        Task DeleteViTri(int id);
    }
}