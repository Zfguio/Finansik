using Finansik.Service.DTO;
using SQLite;
using System.Transactions;

namespace Finansik.Service
{
   static class TransatcionService
    {
       static SQLiteAsyncConnection db;
        static async Task init()
        {
            if (db != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "DataBase.db");
            

            db = new SQLiteAsyncConnection(dbPath);
            // C://Users//User//AppData//Local\\Packages\\com.companyname.finansik_9zz4h110yvjzm\\LocalState\\DataBase.db"
            //C:\Users\User\AppData\Local\Packages\com.companyname.finansik_9zz4h110yvjzm\LocalState znalezienie tego syfu
            await db.CreateTableAsync<Transatcion>();
        }
       static public  async Task addTransatcion(string title, float price, string type)
        {
            await init();
            var transatcion = new Transatcion
            {
                Title = title,
                Price = price,
                Type = type
            };


            await db.InsertAsync(transatcion);
        }
    }
}
