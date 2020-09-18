using BLVGestao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IPessoaRepositorio : IRepositorioBase<Pessoa>
    {
        Task Inativar(int id, Pessoa cliente);
        Task Ativar(int id, Pessoa cliente);
        Task<Pessoa> ConsultarPorIdCompleto(int id);

    }
}
