using GameResultApi.Helpers;
using GameResultApi.Infrastructure.Enum;
using GameResultApi.Infrastructure.Response;
using GameResultApi.Repositories;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System;

namespace GameResultApi.Controllers
{
    public class LeaderBoardController : ApiController
    {
        #region Attributes
        private const string internalError = "Internal Error";
        private readonly ILeaderBoardRepository leaderBoardRepository;
        #endregion

        #region Construct
        public LeaderBoardController()
        {
            leaderBoardRepository = new LeaderBoardRepository();
        }
        #endregion

        [HttpGet]
        [Route("GameResult/GetLeaderBoard")]
        [ResponseType(typeof(string))]
        /// <summary>
        /// Return LeaderBoard for all Users with Scores
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<IHttpActionResult> GetLeaderBoardAsync()
        {
            try
            {
                LeaderBoardRS response = new LeaderBoardRS();

                response = await leaderBoardRepository.GetLeaderBoard();
                
                if (response == null)
                    response.TransactionStatus = TransactionStatusHelper.CreateTransaction(HttpStatusCode.BadRequest.ToString(), internalError, EndTransactionType.Error, ErrorType.ProgrammerError);
             
                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception source: {0}", e.Source);
                return null;
            }
        }
    }
}
