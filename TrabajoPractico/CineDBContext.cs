using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace TrabajoPractico
{
    public class CineDBContext : DbContext
    {
        //public CineDBContext(): base()
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=localhost;Database=CineDB;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionBuilder);
        }
        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Funciones> Funciones { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Salas> Salas { get; set; }
        public DbSet<Generos> Generos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peliculas>(entity =>
            {
                entity.HasKey(p => p.PeliculaId);
                entity.Property(p => p.Titulo).HasMaxLength(50);
                entity.Property(p => p.Sinopsis).HasMaxLength(255);
                entity.Property(p => p.Poster).HasMaxLength(100);
                entity.Property(p => p.Trailer).HasMaxLength(100);
                entity.Property(p => p.PeliculaId).ValueGeneratedOnAdd();
                entity.HasOne<Generos>(p => p.Generos)  
                    .WithMany(g => g.Peliculas)
                    .HasForeignKey(p => p.Genero);
                entity.HasMany<Funciones>(f => f.Funciones)
                    .WithOne(p => p.Peliculas);
            });
            modelBuilder.Entity<Generos>(entity =>
            {
                entity.HasKey(g => g.GeneroId);
                entity.Property(g => g.Nombre).HasMaxLength(50);
                entity.Property(v => v.GeneroId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Funciones>(entity =>
            {
                entity.HasKey(e => e.FuncionId);
                entity.Property(v => v.FuncionId).ValueGeneratedOnAdd();
                entity.HasOne<Peliculas>(p => p.Peliculas)
                    .WithMany(f => f.Funciones)
                    .HasForeignKey(p => p.PeliculaId);
                entity.HasOne<Salas>(s => s.Salas)
                 .WithMany(f => f.Funciones)
                 .HasForeignKey(s => s.SalaId);
            });
            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.HasKey(t => new {t.TicketId,t.FuncionId});
                entity.Property(t => t.Usuario).HasMaxLength(50);
                entity.Property(t => t.TicketId).ValueGeneratedOnAdd();
                entity.HasOne<Funciones>(f => f.Funciones).WithMany(t => t.Tickets)
                .HasForeignKey(f => f.FuncionId );
            });
            modelBuilder.Entity<Salas>(entity =>
            {
                entity.HasKey(e => e.SalaId);
                entity.Property(p => p.Nombre).HasMaxLength(50);
                entity.Property(v => v.SalaId).ValueGeneratedOnAdd();
            });
        }
    }
}
