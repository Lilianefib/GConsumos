using System.Linq;
using System.Threading.Tasks;
using GConsumos.Domain;
using GConsumos.Persistence.Contextos;
using GConsumos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GConsumos.Persistence
{
    public class MedidorPersist: IMedidorPersist
    {
        private readonly GConsumosContext _context;
        public MedidorPersist(GConsumosContext context)
        {
            _context = context;
            
        }
        public async Task<Medidor[]> GetAllMedidoresAsync()
        {            
            IQueryable<Medidor> query = _context.Medidores;

            query = query.AsNoTracking().OrderBy(m => m.Id);

            return await query.ToArrayAsync();           
        }
        public async Task<Medidor> GetMedidorByIdAsync(int MedidorId)
        {
            IQueryable<Medidor> query = _context.Medidores;

            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Id == MedidorId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Medidor[]> GetAllMedidoresByMedidorAsync(string medidor)
        {
            IQueryable<Medidor> query = _context.Medidores;
            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.numeroMedidor.ToLower().Contains(medidor.ToLower()));

            return await query.ToArrayAsync();
                
        }
       
    }
}