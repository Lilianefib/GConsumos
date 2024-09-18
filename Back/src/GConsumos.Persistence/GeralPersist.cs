using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GConsumos.Persistence.Contextos;
using GConsumos.Persistence.Contratos;

namespace GConsumos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
       private readonly GConsumosContext _context;
       public GeralPersist(GConsumosContext context)
       {
            _context = context;
         
       }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}