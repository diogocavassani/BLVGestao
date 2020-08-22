namespace BLVGestao.Domain.Model
{
    public class Endereco : EntityBase
    {
        public Endereco(int enderecoId, int pessoaId, string logradouro, string numero, string bairro, bool ativo)
            : base(ativo)
        {
            EnderecoId = enderecoId;
            PessoaId = pessoaId;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;

        }
        public int EnderecoId { get; private set; }
         public int PessoaId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        
        public virtual Pessoa Pessoa { get; set; }
        
    }
}