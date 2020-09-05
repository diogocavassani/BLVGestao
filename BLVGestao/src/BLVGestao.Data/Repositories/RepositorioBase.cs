using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly Context _context;
        public RepositorioBase(Context context)
        {
            _context = context;
        }


        async public Task Alterar(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        async public Task Inserir(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        async public Task<T> ListarPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        async public Task<ICollection<T>> ListarTodos()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
