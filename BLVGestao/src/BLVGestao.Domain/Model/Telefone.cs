using BLVGestao.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BLVGestao.Domain.Model
{
    public class Telefone : EntityBase
    {
        public Telefone(int telefoneId, int pessoaId, string numero, TipoTelefoneEnum tipoTelefone)
        {
            TelefoneId = telefoneId;
            PessoaId = pessoaId;
            Numero = numero;
            TipoTelefone = tipoTelefone;          
        }
        public Telefone()
        {

        }
        public int TelefoneId { get; set; }
        public int PessoaId { get; set; }
        [MaxLength(13, ErrorMessage = "Este campo deve conter entre 3 e 13 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 13 caracteres")]
        public string Numero { get; set; }
        public TipoTelefoneEnum TipoTelefone { get; set; }

        public virtual Pessoa Pessoa { get; set; }

    }
}