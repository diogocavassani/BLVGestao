namespace BLVGestao.Domain.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual GrupoAcesso GrupoAcesso { get; set; }
        public bool Ativo { get; set; }

        public Usuario() { Ativo = true; }

    }
}
