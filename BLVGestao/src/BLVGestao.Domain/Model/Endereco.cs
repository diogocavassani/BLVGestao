namespace BLVGestao.Domain.Model
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        
       
        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
    }
}