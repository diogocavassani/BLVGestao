using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Telefone : EntityBase
    {
        public Telefone(int telefoneId, int pessoaId, int numero, TipoTelefoneEnum tipoTelefone, bool ativo)
            :base(ativo)
        {
            TelefoneId = telefoneId;
            PessoaId = pessoaId;
            Numero = numero;
            TipoTelefone = tipoTelefone;          
        }
        public int TelefoneId { get; private set; }
        public int PessoaId { get; private set; }
        public int Numero { get; private set; }
        public TipoTelefoneEnum TipoTelefone { get; private set; }

        public virtual Pessoa Pessoa { get; set; }

    }
}