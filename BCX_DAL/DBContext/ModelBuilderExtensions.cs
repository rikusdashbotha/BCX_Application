
using BCX_CORE.Objects.Employees;
using BCX_CORE.Objects.EmployeeTasks;
using BCX_CORE.Objects.Roles;
using BCX_CORE.Objects.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCX_DAL.DBContext
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                    new Role
                    {
                        Id = 101,
                        CANCELLED = false,
                        Name = "Level 1",
                        RatePerHour = 50.0
                    },
                    new Role
                    {
                        Id = 102,
                        CANCELLED = false,
                        Name = "Level 2",
                        RatePerHour = 100.0
                    });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    CANCELLED = false,
                    FirstName = "Foo",
                    LastName = "Bar",
                    RoleId = 101,
                },
                new Employee
                {
                    Id = 2,
                    CANCELLED = false,
                    FirstName = "Bob",
                    LastName = "Newbie",
                    RoleId = 102,
                });

            modelBuilder.Entity<Task>().HasData(
                    new Task
                    {
                        Id = 201,
                        CANCELLED = false,
                        Name = "Task 1",
                        Duration = 20
                    },
                    new Task
                    {
                        Id = 202,
                        CANCELLED = false,
                        Name = "Task 2",
                        Duration = 30
                    });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 10,
                    TaskId = 201,
                    EmployeeId = 1,
                    CANCELLED = false
                }
                );

            
        }

    }
}
