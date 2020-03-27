using System;
using Microsoft.EntityFrameworkCore;
using ASPNetCore_API.Models;

namespace ASPNetCore_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}
