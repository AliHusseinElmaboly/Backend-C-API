using GameResultApi.Infrastructure.Response;
using System.Threading.Tasks;

namespace GameResultApi.Repositories
{
    public interface ILeaderBoardRepository
    {
        Task<LeaderBoardRS> GetLeaderBoard();
    }
}
