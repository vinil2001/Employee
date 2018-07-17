using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Models
{
    public class Context : DbContext
    {
        public  DbSet<Employee> Employees { get; set; }
        public  DbSet<Job> Jobs { get; set; }
        public  DbSet<EmployeeJob> EmployeeJobs { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmployeeJob>()
        //        .HasKey(t => new { t.EmployeeId, t.JobId });

        //    modelBuilder.Entity<EmployeeJob>()
        //        .HasOne(pt => pt.Employee)
        //        .WithMany(p => p.EmployeeJobs)
        //        .HasForeignKey(pt => pt.EmployeeId);

        //    modelBuilder.Entity<EmployeeJob>()
        //        .HasOne(pt => pt.Job)
        //        .WithMany(t => t.EmployeeJobs)
        //        .HasForeignKey(pt => pt.JobId);
        //}

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
