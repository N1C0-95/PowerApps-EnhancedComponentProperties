using Dapper;
namespace GameStore.Data
{
    public class DatabaseInitializer
    {

        private readonly IDbConnectionFactory _connectionFactory;
        public DatabaseInitializer(IDbConnectionFactory dbConnectionFactory)
        {
            this._connectionFactory = dbConnectionFactory;
        }

        public async Task InitializeAsync()
        {
            using var connection = await _connectionFactory.CreateConnetionAsync();
            await connection.ExecuteAsync(@"
                CREATE TABLE IF NOT EXISTS Games (
                     Upc TEXT PRIMARY KEY,
                     Name TEXT NOT NULL, 
                     ShortDescription TEXT NOT NULL, 
                     Price INTEGER,
                     ReleasedDate TEXT NOT NULL
             )");
        }
    }
}
