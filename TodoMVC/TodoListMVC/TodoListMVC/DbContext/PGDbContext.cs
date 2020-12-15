using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoListMVC.Models
{
    public class PGDbContext : DbContext
    {
        public PGDbContext() : base(nameOrConnectionString: "DefaultConnectionString") { }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
    }
}