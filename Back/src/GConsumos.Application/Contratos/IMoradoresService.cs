using System.Threading.Tasks;
using GConsumos.Application.Dtos;

namespace GConsumos.Application.Contratos
{
    public interface IMoradoresService
    {
        Task<MoradorDto> AddMorador(MoradorDto model);
        Task<MoradorDto> UpdateMorador(int moradorId, MoradorDto model);
        Task<bool> DeleteMorador(int moradorId);

        Task<MoradorDto[]> GetAllMoradorByNomeAsync(string nome);
        Task<MoradorDto[]> GetAllMoradoresAsync();
        Task<MoradorDto> GetMoradorByIdAsync(int MoradorId);
    }
}