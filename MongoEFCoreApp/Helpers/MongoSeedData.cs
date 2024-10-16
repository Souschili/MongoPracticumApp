﻿using MongoDB.Driver;
using MongoEFCoreApp.Entity;
namespace MongoEFCoreApp.Helpers
{
    internal static class MongoSeedData
    {
        public static async Task UploadUserData(IMongoCollection<User> collection)
        {
            List<User> users = new List<User>();
            var random=new Random();

            string[] names = {
                "Aylin", "Eli", "Farid", "Leyla", "Rashad",
                "Nigar", "Elvin", "Gulnar", "Sadiq", "Aysel",
                "Vusal", "Zara", "Kamran", "Fidan", "Murad",
                "Sevda", "Arif", "Gunel", "Nigar", "Tural",
                "Chingiz","Orkhan","Aida","Saida"
            };
            for (int i = 0; i < 100; i++)
            {
                string name = names[random.Next(names.Length)];
                int age = random.Next(18, 78);
                var user = new User
                {
                    Name = name,
                    Age = age,
                    Email = $"{name.ToLower()}{age}@example.az",
                    isActive = random.Next(0, 2) == 1
                };
                users.Add(user);
            }
            
            await collection.InsertManyAsync(users);
            
        }

    }
}
