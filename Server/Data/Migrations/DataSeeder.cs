using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

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
          lightPin: 2,
          hasDoor: true,
          doorPin: 3
      );

      migrationBuilder.AddRoom(
          roomName: "Living Room",
          lightPin: 4,
          hasDoor: true,
          doorPin: 17
      );

      migrationBuilder.AddRoom(
          roomName: "Principal Bedroom",
          lightPin: 27,
          hasDoor: true,
          doorPin: 22
      );

      migrationBuilder.AddRoom(
          roomName: "Secondary Bedroom",
          lightPin: 10,
          hasDoor: true,
          doorPin: 9
      );

      migrationBuilder.AddRoom(
          roomName: "Dining Room",
          lightPin: 11
      );

      return migrationBuilder;
    }
  }
}
