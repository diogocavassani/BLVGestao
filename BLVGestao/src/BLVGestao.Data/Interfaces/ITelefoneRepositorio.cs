using BLVGestao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface ITelefoneRepositorio : IRepositorioBase<Telefone>
    {
        Task AlterarTelefoneComPessoa(Telefone telefone);
        Telefone BuscarComInclude(int id);
    }
}
