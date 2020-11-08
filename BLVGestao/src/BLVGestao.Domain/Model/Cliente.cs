using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Cliente : Pessoa
    {
        public Cliente(int pessoaId, string nome, DateTime dataNascimento, string cpf, string rg)

        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Rg = rg;
            TipoPessoa = TipoPessoaEnum.PessoaFisica;
        }

        public Cliente()
        {
            TipoPessoa = TipoPessoaEnum.PessoaFisica;
        }

        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 5 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public ContaReceber ContaReceber { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
