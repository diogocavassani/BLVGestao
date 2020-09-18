using BLVGestao.Domain.Enums;
using BLVGestao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLVGestao.Mvc.Models
{
    public class CadastroClienteViewModel
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string  Rg { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public TipoTelefoneEnum TipoTelefone { get; set; }


    }
}
