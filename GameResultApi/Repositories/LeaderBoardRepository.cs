using GameResultApi.Infrastructure.DataBase;
using GameResultApi.Infrastructure.Response;
using System.Threading.Tasks;

namespace GameResultApi.Repositories
{
    public class LeaderBoardRepository : ILeaderBoardRepository
    {
        public async Task<LeaderBoardRS> GetLeaderBoard()
        {
            return await DBManager.Instance.GetLeaderBoardAsync();
        }
    }
}