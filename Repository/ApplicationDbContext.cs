using System.Collections.Generic;
using System.Reflection.Emit;
using TicketCinema.Models.DomainModels;
using TicketCinema.Models.Identity;
using TicketCinema.Models.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace TicketCinema.Repository
{
    public class ApplicationDbContext : IdentityDbContext<TicketCinemaAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCards { get; set; }
        public virtual DbSet<MovieInShoppingCart> ProductInShoppingCarts { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieInShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieInShoppingCart>()
                .HasOne(z => z.CurrentMovie)
                .WithMany(z => z.MovieInShoppingCarts)
                .HasForeignKey(z => z.MovieId);

            builder.Entity<MovieInShoppingCart>()
                .HasOne(z => z.UserCart)
                .WithMany(z => z.MovieInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<ShoppingCart>()
                .HasOne<TicketCinemaAppUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);

            builder.Entity<MovieInOrder>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieInOrder>()
                .HasOne(z => z.Movie)
                .WithMany(z => z.MovieInOrders)
                .HasForeignKey(z => z.MovieId);

            builder.Entity<MovieInOrder>()
                .HasOne(z => z.Order)
                .WithMany(z => z.MovieInOrders)
                .HasForeignKey(z => z.OrderId);
        }
    }
}