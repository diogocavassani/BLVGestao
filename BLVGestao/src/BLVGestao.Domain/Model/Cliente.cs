using System;
using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Cliente : Pessoa
    {
        public Cliente(int pessoaId, TipoPessoaEnum tipoPessoa, string nome, DateTime dataNascimento, string cpf, string rg, bool ativo) 
            : base(pessoaId, tipoPessoa, ativo)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Rg = rg;            
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }

        public ContaReceber ContaReceber { get; set; }
    }
}
