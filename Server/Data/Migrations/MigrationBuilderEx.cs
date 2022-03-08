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

            String[] names = new String[properties.Length];
            Object[] values = new Object[properties.Length];

            for (int i = 0; i < properties.Length; i++)
            {
                names[i] = properties[i].Name;
                values[i] = properties[i].GetValue(data, null);
            }

            migrationBuilder.InsertData(modelType.Name, names, values);

            return migrationBuilder;
        }
    }
}
