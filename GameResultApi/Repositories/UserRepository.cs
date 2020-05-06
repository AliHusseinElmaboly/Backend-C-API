using GameResultApi.Infrastructure.DataBase;
using GameResultApi.Infrastructure.Request;
using System.Threading.Tasks;

namespace GameResultApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> Add(UserRQ userName)
        {
            return await DBManager.Instance.RegisterUserAsync(userName);
        }
    }
}