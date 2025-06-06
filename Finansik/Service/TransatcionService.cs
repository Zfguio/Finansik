using Finansik.Service.DTO;
using SQLite;
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
            await db.CreateTableAsync<Finanse>();
        }
        static public async Task addTransatcion(string title, float price, string type)
        {
            await init();
            var transatcion = new Finanse
            {
                Title = title,
                Price = price,
                Type = type
            };
            await db.InsertAsync(transatcion);
        }

        static public async Task addTransatcion(string title, float price, string type, string descreption)
        {
            await init();
            var transatcion = new Finanse
            {
                Title = title,
                Price = price,
                Type = type,
                Description = descreption
            };
            await db.InsertAsync(transatcion);
        }
        static public async Task<int> GetList()
        {
            await init();
            List<Finanse> list = await db.Table<Finanse>().ToListAsync();

            var count = await db.ExecuteScalarAsync<int>("select count(*) from Finanse");
            return count;
        }
        static public async Task<List<Finanse>> GetListAsync()
        {
            init();
            try
            {
                if (db == null)
                {
                    return null;
                }
                return await db.Table<Finanse>().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
