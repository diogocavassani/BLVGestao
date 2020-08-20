using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLVGestao.Data.Interfaces;
using BLVGestao.Domain.Model;

namespace BLVGestao.Data.Repositories
{
    public class GrupoAcessoRepositorio : IRepositorioBase<GrupoAcesso>, IGrupoAcessoRepositorio
    {
        public Task<IEnumerable<GrupoAcesso>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GrupoAcesso>> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(GrupoAcesso entity)
        {
            throw new NotImplementedException();
        }

        public Task Alterar(GrupoAcesso entity)
        {
            throw new NotImplementedException();
        }
    }
}