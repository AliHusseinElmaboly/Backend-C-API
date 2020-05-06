using GameResultApi.Infrastructure.Request;
using GameResultApi.Infrastructure.Response;
using System.Threading.Tasks;

namespace GameResultApi.Repositories
{
    public interface IGameResultRepository
    {
        Task<GameResultRS> Add(GameResultRQ gameResultRQ);
    }
}
