namespace BLVGestao.Domain.Model
{
    public class Fornecedor : Pessoa
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }


        public Fornecedor()
        {
            TipoPessoa = Enums.TipoPessoa.PessoaJuridica;
        }
    }


}
