using System.Data;

namespace GameStore.Data
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnetionAsync();
    }
}
