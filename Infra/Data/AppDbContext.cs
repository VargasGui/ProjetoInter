using ISoccer.Infra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISoccer.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<News> News { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<User>().Property(p => p.DisplayName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<User>().Ignore(u => u.Password);
            modelBuilder.Entity<User>().Property(p => p.Phone).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.isAdmin).IsRequired();

            modelBuilder.Entity<Team>().HasKey(p => p.Id);
            modelBuilder.Entity<Team>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Team>().Property(p => p.Image);

            modelBuilder.Entity<News>().HasKey(p => p.Id);
            modelBuilder.Entity<News>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<News>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<News>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<News>().Property(p => p.Image);
            modelBuilder.Entity<News>().Property(p => p.Date).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<News>().Property(p => p.Source).IsRequired();

            modelBuilder.Entity<GameStatus>().HasData(
            new GameStatus { Id = 1, Type = "Agendado" },
            new GameStatus { Id = 2, Type = "Em andamento" },
            new GameStatus { Id = 2, Type = "Intervalo" },
            new GameStatus { Id = 2, Type = "Finalizado" },
            new GameStatus { Id = 2, Type = "Interrompido" },
            new GameStatus { Id = 2, Type = "Adiado" },
            new GameStatus { Id = 2, Type = "Abandonado" }
            );

            modelBuilder.Entity<Game>().HasKey(p => p.Id);
            modelBuilder.Entity<Game>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Game>().Property(p => p.Date).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Game>().Property(p => p.Place).IsRequired();
            modelBuilder.Entity<Game>().Property(p => p.ResultTeamOne).HasMaxLength(2);
            modelBuilder.Entity<Game>().Property(p => p.ResultTeamTwo).HasMaxLength(2);

            modelBuilder.Entity<Championship>().HasKey(p => p.Id);
            modelBuilder.Entity<Championship>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Championship>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Championship>().Property(p => p.Image);
            modelBuilder.Entity<Championship>().Property(p => p.Rounds).HasMaxLength(2);

            //Relacionamentos
            modelBuilder.Entity<News>()
                .HasOne(n => n.Team)           // News tem uma referência para Team
                .WithMany(t => t.NewsList)     // Team tem muitas News
                .HasForeignKey(n => n.TeamId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.GameStatus)
                .WithOne()
                .HasForeignKey<Game>(g => g.StatusId);





            ////Relacionamentos
            //modelBuilder.Entity<Story>().HasMany(p => p.Votes).WithOne(p => p.Story).HasForeignKey(p => p.StoryId);
            //modelBuilder.Entity<User>().HasMany(x => x.Votes).WithOne(x => x.User).HasForeignKey(x => x.UserId);

        }
    }
}
