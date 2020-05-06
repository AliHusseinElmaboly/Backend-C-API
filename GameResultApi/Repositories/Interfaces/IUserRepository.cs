using GameResultApi.Infrastructure.Request;
using System.Threading.Tasks;

namespace GameResultApi.Repositories
{
    public interface IUserRepository
    {
         Task<bool> Add(UserRQ userName);
    }
}
