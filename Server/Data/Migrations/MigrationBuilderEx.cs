using System.Collections.Generic;
using System;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

#nullable disable

namespace Data.Migrations
{
    internal static class MigrationBuilderEx
    {
        internal static MigrationBuilder AddData(this MigrationBuilder migrationBuilder, Model[] data)
        {
            foreach (Model model in data)
                migrationBuilder.AddObjectData(model);

            return migrationBuilder;
        }

        internal static MigrationBuilder AddData(this MigrationBuilder migrationBuilder, Model data)
            => migrationBuilder.AddObjectData(data);
        internal static MigrationBuilder AddRoom(this MigrationBuilder migrationBuilder, String roomName, int lightPin, Boolean hasDoor = false, int doorPin = 0)
        {
            Room room = new Room
            {
                Id = Guid.NewGuid(),
                Name = roomName,
            };

            Light light = new Light
            {
                Id = Guid.NewGuid(),
                Pin = lightPin,
                RoomId = room.Id,
                Room = room
            };

            room.Light = light;

            migrationBuilder.AddData(new Model[]
            {
                room,
                light,

            });

            if (hasDoor)
            {
                Door door = new Door
                {
                    Id = Guid.NewGuid(),
                    Pin = doorPin,
                    RoomId = room.Id,
                    Room = room
                };

                room.Doors.Add(door);

                migrationBuilder.AddData(door);
            }

            return migrationBuilder;
        }

        internal static MigrationBuilder AddUserData(this MigrationBuilder migrationBuilder, Dictionary<User, String> data)
        {
            var normalizer = new UpperInvariantLookupNormalizer();

            foreach (var item in data)
            {
                User model = item.Key;

                model.Id = Guid.NewGuid();
                model.UserName = model.Email;
                model.NormalizedEmail = normalizer.NormalizeEmail(model.Email);
                model.NormalizedUserName = normalizer.NormalizeName(model.Email);
                model.PasswordHash = new PasswordHasher<User>()
                    .HashPassword(model, item.Value);
                model.SecurityStamp = Guid.NewGuid().ToString();
                model.ConcurrencyStamp = Guid.NewGuid().ToString();
                model.LockoutEnabled = true;

                migrationBuilder.AddObjectData(model);
            }

            return migrationBuilder;
        }

        private static MigrationBuilder AddObjectData(this MigrationBuilder migrationBuilder, Object data)
        {
            Type modelType = data.GetType();
            PropertyInfo[] properties = modelType.GetProperties();

            List<String> names = new List<String>();
            List<Object> values = new List<Object>();

            for (int i = 0; i < properties.Length; i++)
            {
                if(isModelType(properties[i].PropertyType))
                    continue;

                names.Add(properties[i].Name);
                values.Add(properties[i].GetValue(data, null));
            }

            migrationBuilder.InsertData(
                modelType.Name, 
                names.ToArray(), 
                values.ToArray()
            );

            return migrationBuilder;
        }

        private static Boolean isModelType(this Type prop)
        {
            if(prop.IsSubclassOf(typeof(Model)))
                return true;

            if (prop.GenericTypeArguments.Length > 0)
                return prop.GenericTypeArguments.ToList().Select(type => 
                    type.IsSubclassOf(typeof(Model))).Contains(true);

            return false;
        }
    }
}
