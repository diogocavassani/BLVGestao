using System;

namespace BLVGestao.Domain.Model
{
    public class Cliente : Pessoa
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public Cliente()
        {
            TipoPessoa = Enums.TipoPessoa.PessoaFisica;
        }
    }
}
