using Microsoft.Data.Sqlite;
using System.Data;



namespace GameStore.Data
{
    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        private string _connectionString;
        public SqliteConnectionFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public async Task<IDbConnection> CreateConnetionAsync()
        {
            var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
