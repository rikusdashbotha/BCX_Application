
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.Hours;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.TaskAssigns;
using BCX_CORE.Objects.Tasks;
using BCX_DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace BCX_DAL.Context
{
    public class BCX_DBContext : DbContext
    {
        public BCX_DBContext(DbContextOptions<BCX_DBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Additional Info https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=data-annotations%2Cfluent-api-simple-key%2Csimple-key


            modelBuilder.Entity<Employee>()
                .HasOne(c => c.Role)
                .WithMany(o => o.Employees)
                .HasForeignKey(c => c.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            //Many to Many relationship
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(c => c.Employee)
                .WithMany(c => c.EmployeeTasks)
                .HasForeignKey(c => c.EmployeeId);

            modelBuilder.Entity<EmployeeTask>()
               .HasOne(c => c.Task)
               .WithMany(c => c.EmployeeTasks)
               .HasForeignKey(c => c.TaskId);

            modelBuilder.Entity<Hour>()
                .HasOne(c => c.Employee)
                .WithMany(c => c.Hours)
                .HasForeignKey(c => c.EmployeeId);


            modelBuilder.Seed();
            
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskAssign> TaskAssigns { get; set; }

        public DbSet<Hour> Hours { get; set; }
    }
}
