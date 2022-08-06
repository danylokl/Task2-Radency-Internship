﻿using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Title = "title1", Content = "content 1", Cover = "Hardcover", Genre = "Fantasy" ,/*Ratings=new List<Rating>() { new Rating{ BookId = 1 }*/ },
                 new Book() { Id = 2, Title = "title2", Content = "content 2", Cover = "Lightcover", Genre = "Romance" },
                 new Book() { Id = 3, Title = "title3", Content = "content 3", Cover = "Hardcover", Genre = "Fantasy" },
                 new Book() { Id = 4, Title = "title4", Content = "content 4", Cover = "Lightcover", Genre = "Horror" },
                 new Book() { Id = 5, Title = "title5", Content = "content 5", Cover = "Hardcover", Genre = "Romance" },
                 new Book() { Id = 6, Title = "title6", Content = "content 6", Cover = "Hardcover", Genre = "Fantasy" },
                 new Book() { Id = 7, Title = "title7", Content = "content 7", Cover = "Lightcover", Genre = "Horror" },
                 new Book() { Id = 8, Title = "title8", Content = "content 8", Cover = "Hardcover", Genre = "Romance" },
                 new Book() { Id = 9, Title = "title9", Content = "content 9", Cover = "Hardcover", Genre = "Fantasy" },
                 new Book() { Id = 10, Title = "title10", Content = "content 10", Cover = "Lightcover", Genre = "Horror" }
                );
            modelBuilder.Entity<Rating>().HasData(
                new Rating() { Id = 1, Score = 7, BookId = 1 },
                new Rating() { Id = 2, Score = 6.8, BookId = 2 },
                new Rating() { Id = 3, Score = 9.5, BookId = 4 },
                new Rating() { Id = 4, Score = 7.5, BookId = 5 },
                new Rating() { Id = 5, Score = 8, BookId = 6 },
                new Rating() { Id = 6, Score = 2, BookId = 7 },
                new Rating() { Id = 7, Score = 10, BookId = 8 },
                new Rating() { Id = 8, Score = 4, BookId = 9 },
                new Rating() { Id = 9, Score = 8, BookId = 10 },
                 new Rating() { Id = 10, Score = 7, BookId = 1 }
                );
            modelBuilder.Entity<Review>().HasData(
                new Review() { Id = 1, Message = "some message 1", Reviewer = "Fatima Dyer", BookId = 2 },
                new Review() { Id = 2, Message = "some message 2", Reviewer = "Chelsea West", BookId = 3 },
                new Review() { Id = 3, Message = "some message 3", Reviewer = "Sierra Travis", BookId = 4 },
                new Review() { Id = 4, Message = "some message 4", Reviewer = "Gary Chapman", BookId = 5 },
                new Review() { Id = 5, Message = "some message 5", Reviewer = "Akeem Chan", BookId = 7 },
                new Review() { Id = 6, Message = "some message 6", Reviewer = "Ciaran Montgomery", BookId = 1 },
                new Review() { Id = 7, Message = "some message 7", Reviewer = "Matthew Jackson", BookId = 5 },
                new Review() { Id = 8, Message = "some message 8", Reviewer = "Orla Greene", BookId = 9 },
                new Review() { Id = 9, Message = "some message 9", Reviewer = "Chaim West", BookId = 10 },
                new Review() { Id = 10, Message = "some message 10", Reviewer = "Ivory Banks", BookId = 5 }
                //new Review() { Id = 1, Message = "some message 1", Reviewer = "Fatima Dyer" },
                //new Review() { Id = 2, Message = "some message 2", Reviewer = "Chelsea West" },
                //new Review() { Id = 3, Message = "some message 3", Reviewer = "Sierra Travi" },
                //new Review() { Id = 4, Message = "some message 4", Reviewer = "Gary Chapman" },
                //new Review() { Id = 5, Message = "some message 5", Reviewer = "Akeem Chan" },
                //new Review() { Id = 6, Message = "some message 6", Reviewer = "Ciaran Montg" },
                //new Review() { Id = 7, Message = "some message 7", Reviewer = "Matthew Jack" },
                //new Review() { Id = 8, Message = "some message 8", Reviewer = "Orla Greene" },
                //new Review() { Id = 9, Message = "some message 9", Reviewer = "Chaim West" },
                //new Review() { Id = 10, Message = "some message 10", Reviewer = "Ivory Bank" }
                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-E3LF3J7\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}
