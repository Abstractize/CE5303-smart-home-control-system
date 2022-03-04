using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    internal static class DataSeeder
    {
        internal static MigrationBuilder SeedInitialData(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUserData(new Dictionary<User, String>(){
                { new User { Name = "Juanito", Email = "email@email.com" }, "password" } 
            });
            
            return migrationBuilder;
        }
    }
}
