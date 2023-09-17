using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Car_Management.Data
{
    public class Car_ManagementContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Car_ManagementContext() : base("name=Car_ManagementContext")
        {
        }

        public System.Data.Entity.DbSet<Car_Management.Models.CarModel> CarModels { get; set; }
    }
}
