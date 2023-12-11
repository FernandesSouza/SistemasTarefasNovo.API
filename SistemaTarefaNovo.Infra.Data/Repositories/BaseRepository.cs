using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTarefaNovo.Domain.Entities;
using SistemaTarefaNovo.Domain.Interfaces;
using SistemaTarefaNovo.Infra.Data.Data;

namespace SistemaTarefaNovo.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BancoContext _context;

        public BaseRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletar = await _context.Set<T>().FindAsync(id);

            if (deletar != null)
            {

                _context.Remove(deletar);
                await _context.SaveChangesAsync();


            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var query = await _context.Set<T>().FindAsync(id);
            return query;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
