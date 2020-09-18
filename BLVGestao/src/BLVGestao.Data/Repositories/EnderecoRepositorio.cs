using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLVGestao.Data.Repositories
{
    public class EnderecoRepositorio : RepositorioBase<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(Context context) : base(context)
        {
        }

        async public Task AlterarEnderecoComPessoa(Endereco endereco)
        {
            var enderecoCompleto = BuscarComInclude(endereco.EnderecoId);
            endereco.PessoaId = enderecoCompleto.PessoaId;
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
        }

        public Endereco BuscarComInclude(int id)
        {
            return _context.Enderecos.Include(e => e.Pessoa).Where(e => e.EnderecoId == id).AsNoTracking().FirstOrDefault();
        }
    }
}
