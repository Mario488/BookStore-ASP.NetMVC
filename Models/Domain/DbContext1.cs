﻿using Microsoft.EntityFrameworkCore;

namespace BookeStore_application.Models.Domain
{
    public class DbContext1 : DbContext
    {
        public DbContext1(DbContextOptions<DbContext1> options) : base(options)
        {

        }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

    }
}
