using MongoDB.Bson;
using MongoDB.Driver;
using MongoEFCoreApp.Entity;
using MongoEFCoreApp.Helpers;

namespace MongoEFCoreApp
{
    internal class Program
    {
        private static IMongoDatabase _dataBase = new MongoClient().GetDatabase("Demo");
        private static IMongoCollection<User> _usersCol = _dataBase.GetCollection<User>("users");

        static async Task Main(string[] args)
        {
            // seed users to mongo
            // генератор записей для коллекции 
            //await MongoSeedData.UploadUserData(_usersCol);
            await ReadContent();
        }

        // тут запросы на чтение в двух стилях лямбды и фильтры
        public static async Task ReadContent()
        {
            // бьюлдер для фильтров ,добавлен для фильрационых запросов
            FilterDefinitionBuilder<User> filterBuilder = new FilterDefinitionBuilder<User>();

            //1.Найдите одного пользователя с именем "Leyla".
            //FilterDefinition<User> filterTask1= Builders<User>.Filter.Eq(x=> x.Name,"Leyla");
            var task1 = await _usersCol.Find(x => x.Name == "Leyla")
                .FirstOrDefaultAsync();
            Console.WriteLine(task1.ToJson());

            // 2. Получите всех пользователей старше 30 лет.
            //var filterTask2 = filterBuilder.Gt(x => x.Age, 30);
            var task2 = await _usersCol.Find(x => x.Age > 30).ToListAsync();
            // вывод данных
            //Console.WriteLine($"Найдено {task2.Count} записей");
            //task2.ForEach(x => Console.WriteLine(x.ToJson()));

            // 3. Найдите активных пользователей и отсортируйте их по возрасту в порядке возрастания.
            //var filterTask3 = filterBuilder.Eq(x => x.isActive, true);
            var task3 = await _usersCol.Find(x => x.isActive == true).SortBy(x=>x.Age).ToListAsync();

            // 4. Получите список всех пользователей, но отобразите только их имена и адреса электронной почты.

            var task4 = await _usersCol.Find(_ => true).
                Project(x => new { x.Name ,x.Email}).  // work as select
                ToListAsync();
            task4.ForEach(x => Console.WriteLine(x.ToJson()));
            // 5. Найдите первых 5 пользователей, которые не являются активными.
            //var filterTAsk = filterBuilder.Eq(x => x.isActive, false);
            var task5=await _usersCol.Find(x=> !x.isActive).Limit(5).ToListAsync();
        }

    }
}
