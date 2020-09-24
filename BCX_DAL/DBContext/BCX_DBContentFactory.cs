using BCX_DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BCX_DAL.DBContext
{
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BCX_DBContext>
    //{
    //    public BCX_DBContext CreateDbContext(string[] args)
    //    {
    //        //Implement the initializer here since we're not doing it in an ASP.NET Core StartupFile.
    //        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../BCX_HTTPAPI/appsettings.json").Build();
    //        var builder = new DbContextOptionsBuilder<BCX_DBContext>();
    //        var connectionString = configuration.GetConnectionString("DBConnectionString");
    //        builder.UseSqlServer(connectionString);
    //        return new BCX_DBContext(builder.Options);
    //    }
    //}
}
