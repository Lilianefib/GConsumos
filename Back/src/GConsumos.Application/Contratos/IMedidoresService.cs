using System.Threading.Tasks;
using GConsumos.Application.Dtos;

namespace GConsumos.Application.Contratos
{
    public interface IMedidoresService
    {
        Task<MedidorDto> AddMedidor(MedidorDto model);
        Task<MedidorDto> UpdateMedidor(int MedidorId, MedidorDto model);
        Task<bool> DeleteMedidor(int MedidorId);

        Task<MedidorDto[]> GetAllMedidoresByMedidorAsync(string medidor);
        Task<MedidorDto[]> GetAllMedidoresAsync();
        Task<MedidorDto> GetMedidorByIdAsync(int MedidorId);
    }
}