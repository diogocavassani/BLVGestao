using System.ComponentModel.DataAnnotations;

namespace BLVGestao.Domain.Model
{
    public class Endereco : EntityBase
    {
        public Endereco(int enderecoId, int pessoaId, string logradouro, string numero, string bairro)

        {
            EnderecoId = enderecoId;
            PessoaId = pessoaId;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;

        }
        public Endereco()
        {

        }
        public int EnderecoId { get; set; }
         public int PessoaId { get; set; }
        [MaxLength(30, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        public string Logradouro { get; set; }
        [MaxLength(10, ErrorMessage = "Este campo deve conter entre 3 e 10 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 10 caracteres")]
        public string Numero { get; set; }
        [MaxLength(30, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        public string Bairro { get; set; }
        
        public virtual Pessoa Pessoa { get; set; }
        
    }
}