using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GConsumos.Domain;

namespace GConsumos.Persistence.Contratos
{
    public interface IMedidorPersist
    {
        Task<Medidor[]> GetAllMedidoresByMedidorAsync(string medidor);
        Task<Medidor[]> GetAllMedidoresAsync();
        Task<Medidor> GetMedidorByIdAsync(int MedidorId);
    }
}