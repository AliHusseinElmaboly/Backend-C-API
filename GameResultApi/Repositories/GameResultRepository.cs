using GameResultApi.Infrastructure.DataBase;
using GameResultApi.Infrastructure.Request;
using GameResultApi.Infrastructure.Response;
using System.Data;
using System.Threading.Tasks;

namespace GameResultApi.Repositories
{
    public class GameResultRepository : IGameResultRepository
    {
        public async Task<GameResultRS> Add(GameResultRQ gameResultRQ)
        {
            GameResultRS response = new GameResultRS();
            //check if the User is Registed
            DataTable table = await DBManager.Instance.CheckRegistedUser(gameResultRQ);
     
            //Rows of table count > 0 that means the User is registed
            if (table != null && table.Rows.Count > 0)
            {
                response.IsAdded =  await DBManager.Instance.AddGameResultAsync(table, gameResultRQ);
                response.TransactionStatus.Message = string.Format("{0} has score {1} is reported", gameResultRQ.UserName, gameResultRQ.Score);
                return response;
            }
            else
            {
                //User in unregisted and the score doesn't save so return false
                response.TransactionStatus.Message = string.Format("{0} is not registed User", gameResultRQ.UserName);
                response.IsAdded = false;
            }
            return response;
        }
    }
}