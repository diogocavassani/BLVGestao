using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BLVGestao.Data.ORM
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.SetCommandTimeout(60);
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaReceber> ContasReceber { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<FormaDePagamento> FormasDePagamento { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<GrupoAcesso> GruposAcesso { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; } 
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Codigo para pegar todas os Mapeamentos de uma vez. Entretanto os Mapeamentos estão incorretos         
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
