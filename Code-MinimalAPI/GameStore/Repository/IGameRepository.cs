using GameStore.Model;

namespace GameStore.Repository
{
    public interface IGameRepository 
    {
        public Task<bool> CreateAsync(Game game);
        public Task<IEnumerable<Game>> GetAllAsync();
        public Task<Game?> GetByUpcAsync(string upc);
        public Task<IEnumerable<Game>> SearchByNameAsync(string name);
        public Task<bool> UpdateAsync(Game game);
        public Task<bool> DeleteAsync(string upc);

    }
}
