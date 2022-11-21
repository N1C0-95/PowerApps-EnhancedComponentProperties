using GameStore.Data;
using GameStore.Model;
using Dapper;

namespace GameStore.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GameRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this._dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<bool> CreateAsync(Game game)
        {
            var existingGame = await GetByUpcAsync(game.Upc);
            if (existingGame is not null)
            {
                return false;
            }

            using var connection = await _dbConnectionFactory.CreateConnetionAsync();
            var result = await connection.ExecuteAsync(@"
            INSERT INTO Games(Upc, Name, ShortDescription, Price, ReleasedDate) 
            VALUES (@Upc, @Name, @ShortDescription, @Price, @ReleasedDate)", 
            game);
            return result > 0;
        }       
        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            using var connection = await _dbConnectionFactory.CreateConnetionAsync();
            var result = await connection.QueryAsync<Game>(@"SELECT * FROM Games");
            return result;
        }
        public async Task<Game?> GetByUpcAsync(string upc)
        {
            using var connection = await _dbConnectionFactory.CreateConnetionAsync();
            var result = await connection.QueryFirstOrDefaultAsync<Game>(@"SELECT * FROM Games WHERE Upc = @Upc LIMIT 1", new { Upc = upc });
            return result;
        }
        public async Task<IEnumerable<Game>> SearchByNameAsync(string searchTerm)
        {
            using var connection = await _dbConnectionFactory.CreateConnetionAsync();
            return await connection.QueryAsync<Game>("SELECT * FROM Games WHERE Name LIKE '%' || @SearchTerm ||'%'", new { SearchTerm = searchTerm });
        }
        public async Task<bool> UpdateAsync(Game game)
        {
            var existingGame = await GetByUpcAsync(game.Upc);
            if(existingGame is null)
            {
                return false;
            }
            using var connection = await _dbConnectionFactory.CreateConnetionAsync();
            var result = await connection.ExecuteAsync(@"UPDATE Games SET Name=@Name, ShortDescription=@ShortDescription, Price=@Price, ReleasedDate=@ReleasedDate WHERE Upc=@Upc", game);
            return result > 0;
        }
        public async Task<bool> DeleteAsync(string upc)
        {
            using var connection = await _dbConnectionFactory.CreateConnetionAsync();
            var deleted = await connection.ExecuteAsync(@"DELETE FROM Games WHERE Upc = @Upc ", new { Upc = upc });
            return deleted > 0;
        }
    }


}
