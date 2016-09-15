using System.Data.Entity.Migrations;
using ApiRegistry.Data;
using ApiRegistry.Models;
using ApiRegistry.Services;

namespace ApiRegistry.Migrations
{
    public class ApiInfoConfiguration
    {
        public static void Seed(DataContext context) {

            context.SaveChanges();
        }
    }
}
