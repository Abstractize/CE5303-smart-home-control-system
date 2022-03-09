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

            migrationBuilder.AddRoom(
                roomName: "Kitchen", 
                lightPin: 1,
                hasDoor: true,
                doorPin: 2
            );

            migrationBuilder.AddRoom(
                roomName: "Living Room",
                lightPin: 3,
                hasDoor: true,
                doorPin: 4
            );

            migrationBuilder.AddRoom(
                roomName: "Principal Bedroom",
                lightPin: 5,
                hasDoor: true,
                doorPin: 6
            );

            migrationBuilder.AddRoom(
                roomName: "Secondary Bedroom",
                lightPin: 7,
                hasDoor: true,
                doorPin: 8
            );

            migrationBuilder.AddRoom(
                roomName: "Dining Room",
                lightPin: 9
            );

            return migrationBuilder;
        }
    }
}
