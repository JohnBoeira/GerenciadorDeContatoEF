using GerenciadorDeContato.ClassLibrary.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeContato.ClassLibrary.Infraestrutura
{
    public class DominioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=ContatosDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>(c =>
            {
                c.ToTable("TBTelefone");

                c.HasKey(p => p.Id);
                c.Property(p => p.numero).HasColumnType("INT").IsRequired();
                c.Property(p => p.ddd).HasColumnType("INT").IsRequired();

            });

            modelBuilder.Entity<Contato>(c =>
            {
                c.ToTable("TBContato");

                c.HasKey(p => p.Id);
                c.Property(p => p.Nome).HasColumnType("VARCHAR(50)").IsRequired();
                c.HasMany(p => p.Telefones).WithOne(p => p.contato);

            });
        }

        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Telefone> Telefones { get; set; }
    }
}
