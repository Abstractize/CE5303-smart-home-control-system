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
          lightPin: 3,
          hasDoor: true,
          doorPin: 5
      );

      migrationBuilder.AddRoom(
          roomName: "Living Room",
          lightPin: 7,
          hasDoor: true,
          doorPin: 11
      );

      migrationBuilder.AddRoom(
          roomName: "Principal Bedroom",
          lightPin: 13,
          hasDoor: true,
          doorPin: 15
      );

      migrationBuilder.AddRoom(
          roomName: "Secondary Bedroom",
          lightPin: 19,
          hasDoor: true,
          doorPin: 21
      );

      migrationBuilder.AddRoom(
          roomName: "Dining Room",
          lightPin: 23
      );

      return migrationBuilder;
    }
  }
}
