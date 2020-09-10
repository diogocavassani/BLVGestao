using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Telefone : EntityBase
    {
        public Telefone(int telefoneId, int pessoaId, int numero, TipoTelefoneEnum tipoTelefone)
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
        public int Numero { get; set; }
        public TipoTelefoneEnum TipoTelefone { get; set; }

        public virtual Pessoa Pessoa { get; set; }

    }
}