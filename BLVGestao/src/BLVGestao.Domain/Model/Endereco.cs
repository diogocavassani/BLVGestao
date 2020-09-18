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
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        
        public virtual Pessoa Pessoa { get; set; }
        
    }
}