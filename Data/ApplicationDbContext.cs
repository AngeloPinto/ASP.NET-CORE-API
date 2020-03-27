using Microsoft.EntityFrameworkCore;
using System;

namespace ASPNetCore_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base() {}
    }
}