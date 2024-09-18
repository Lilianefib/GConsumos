using System.Linq;
using System.Threading.Tasks;
using GConsumos.Domain;
using GConsumos.Persistence.Contextos;
using GConsumos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace GConsumos.Persistence
{
    public class MoradorPersist: IMoradorPersist
    {
        private readonly GConsumosContext _context;
        public MoradorPersist(GConsumosContext context)
        {
            _context = context;
            
        }
        public async Task<Morador[]> GetAllMoradoresAsync()
        {            
            IQueryable<Morador> query = _context.Moradores
                .Include(m => m.MoradorMedidor)
                .ThenInclude(mm => mm.Medidor);

            query = query.AsNoTracking().OrderBy(m => m.Id);

            return await query.ToArrayAsync();           
        }
        public async Task<Morador> GetMoradorByIdAsync(int MoradorId)
        {
            IQueryable<Morador> query = _context.Moradores
                .Include(m => m.MoradorMedidor)
                .ThenInclude(mm => mm.Medidor);

            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Id == MoradorId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Morador[]> GetAllMoradorByNomeAsync(string nome)
        {
            IQueryable<Morador> query = _context.Moradores
                .Include(m => m.MoradorMedidor)
                .ThenInclude(mm => mm.Medidor);

            query = query.AsNoTracking().OrderBy(m => m.Id).Where(m => m.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
                
        }
       
    }
}