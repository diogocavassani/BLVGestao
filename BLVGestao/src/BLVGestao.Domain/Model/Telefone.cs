using BLVGestao.Domain.Enums;

namespace BLVGestao.Domain.Model
{
    public class Telefone
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public TipoTelefone TipoTelefone { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

    }
}