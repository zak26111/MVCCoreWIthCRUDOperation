using CRUDWithDotNetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUDWithDotNetCoreMVC.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }       
        public DbSet<Customer> Customers { get; set; }
    }
}
