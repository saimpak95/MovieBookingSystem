using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieBooking_DomainModels.Seed
{
   public class SeedDataContext
    {
        public static async Task SeedDataAsync(DataContext db, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!db.Roles.Any())
                {
                    var RoleData = File.ReadAllText("../MovieBooking-DomainModels/Seed/Roles.json");
                    var role = JsonSerializer.Deserialize<List<Role>>(RoleData);
                    foreach (var item in role)
                    {
                        db.Roles.Add(item);
                        await db.SaveChangesAsync();
                    }
                }
                if (!db.Users.Any())
                {
                    var UserData = File.ReadAllText("../MovieBooking-DomainModels/Seed/Users.json");
                    var user = JsonSerializer.Deserialize<List<User>>(UserData);
                    foreach (var item in user)
                    {
                        db.Users.Add(item);
                        await db.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex.Message);
             
            }
        }
    }
}
