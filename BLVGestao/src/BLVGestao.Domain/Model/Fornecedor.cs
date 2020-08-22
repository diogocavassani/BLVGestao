using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Fornecedor : Pessoa
    {
        public Fornecedor(int pessoaId, TipoPessoaEnum tipoPessoa, string razaoSocial, string cnpj, bool ativo) 
            : base(pessoaId, tipoPessoa, ativo)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = NomeFantasia;
            Cnpj = cnpj;
        }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
    }


}
