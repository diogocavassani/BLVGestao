namespace BLVGestao.Domain.Model
{
    public class FormaDePagamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int PrazoRecebimento { get; set; }
        public bool Ativo { get; set; } = true;

        public FormaDePagamento() { Ativo = true; }
    }
}
