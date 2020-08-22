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
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        
        
        
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<FormaDePagamento> FormaDePagamento { get; set; }
        
        public DbSet<GrupoAcesso> GrupoAcesso { get; set; }
        
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Codigo para pegar todas os Mapeamentos de uma vez. Entretanto os Mapeamentos estão incorretos         
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);



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
