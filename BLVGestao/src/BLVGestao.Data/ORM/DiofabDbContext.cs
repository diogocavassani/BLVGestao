using BLVGestao.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BLVGestao.Data.ORM
{
    public class DiofabDbContext : DbContext
    {
        public DiofabDbContext(DbContextOptions<DiofabDbContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(60);
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<FormaDePagamento> FormaDePagamento { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<GrupoAcesso> GrupoAcesso { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Codigo para pegar todas os Mapeamentos de uma vez. Entretanto os Mapeamentos estão incorretos         
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiofabDbContext).Assembly);



            //modelBuilder.ApplyConfiguration(new ClienteMap());
            //modelBuilder.ApplyConfiguration(new EnderecoMap());
            //modelBuilder.ApplyConfiguration(new FornecedorMap());
            //modelBuilder.ApplyConfiguration(new PessoaMap());
            //modelBuilder.ApplyConfiguration(new ProdutoMap());
            //modelBuilder.ApplyConfiguration(new TelefoneMap());
            //modelBuilder.ApplyConfiguration(new UsuarioMap());




        }

        //TODO: Mapping Conforme ITDEvelope
    }
}
