using DDD.Domain.Atletica;
using DDD.Domain.PicContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.SQLServer
{
    public class SqlContext : DbContext
    {

        //https://balta.io/blog/ef-crud
        //https://jasonwatmore.com/post/2022/03/18/net-6-connect-to-sql-server-with-entity-framework-core

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversidadeDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  
            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Disciplinas)
                .WithMany(e => e.Alunos)
                .UsingEntity<Matricula>();
            modelBuilder.Entity<Atleta>()
               .HasMany(e => e.Esportes)
               .WithMany(e => e.Atletas)
               .UsingEntity<ContratoAtleta>();


            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Pesquisador>().ToTable("Pesquisador");
            modelBuilder.Entity<Atleta>().ToTable("Atleta");
            modelBuilder.Entity<Esporte>().ToTable("Esporte");
            modelBuilder.Entity<Campeonato>().ToTable("campeonato");
            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pesquisador> Pesquisadores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Atleta> Atletas { get; set;}
        public DbSet<Esporte> Esportes { get; set; }
        public DbSet<ContratoAtleta> ContratoAtletas { get; set; }
        public DbSet<Campeonato> Campeonatos{ get; set; }
    }
}
