using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model;
using Microsoft.EntityFrameworkCore;

namespace app.src.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<CarteiraEntity> Wallets { get; set; }
        public DbSet<TransferenciaEntity> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarteiraEntity>()
                .HasIndex(x => new {x.CPFCNPJ, x.Email})
                .IsUnique();
            
            modelBuilder.Entity<CarteiraEntity>()
                .Property(x => x.SaldoConta)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<CarteiraEntity>()
                .Property(x => x.UserType)
                .HasConversion<string>();

            modelBuilder.Entity<TransferenciaEntity>()
                .HasKey(x => x.IdTranferencia);
            
            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(x => x.Sender)
                .WithMany()
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.Restrict) //Define açao caso delecao
                .HasConstraintName("FK_Transaction_Sender");

            modelBuilder.Entity<TransferenciaEntity>()
                .Property(x => x.Valor)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(x => x.Receiver)
                .WithMany()
                .HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict) //Impede deleçao em cascata
                .HasConstraintName("FK_Transaction_Receiver");
        }
    }
}