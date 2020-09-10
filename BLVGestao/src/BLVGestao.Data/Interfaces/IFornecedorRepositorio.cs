using BLVGestao.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLVGestao.Data.Interfaces
{
    public interface IFornecedorRepositorio : IRepositorioBase<Fornecedor>
    {
        Task<ICollection<Fornecedor>> ConsultarPorNomeFantasia(string nomeFantasia);
        Task<Fornecedor> ConsultarPorCnpj(string cnpj);
        Task<Fornecedor> ConsultarPorIdCompleto(int id);
    }
}