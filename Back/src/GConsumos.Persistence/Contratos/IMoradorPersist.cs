using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GConsumos.Domain;

namespace GConsumos.Persistence.Contratos
{
    public interface IMoradorPersist
    {
        Task<Morador[]> GetAllMoradorByNomeAsync(string nome);
        Task<Morador[]> GetAllMoradoresAsync();
        Task<Morador> GetMoradorByIdAsync(int MoradorId);
    }
}