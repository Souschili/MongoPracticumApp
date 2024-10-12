using MongoDB.Bson;
using MongoDB.Driver;
using MongoEFCoreApp.Entity;
using MongoEFCoreApp.Helpers;

namespace MongoEFCoreApp
{
    internal class Program
    {
        private static IMongoDatabase _dataBase=new MongoClient().GetDatabase("Demo");
        private static IMongoCollection<User> _usersCol=_dataBase.GetCollection<User>("users");
     
        static async Task Main(string[] args)
        {
            // seed users to mongo
            // генератор записей для коллекции 
            //await MongoSeedData.UploadUserData(_usersCol);
        }

        // тут запросы на чтение 
        public static void ReadConcern()
        {

        }
        
    }
}
