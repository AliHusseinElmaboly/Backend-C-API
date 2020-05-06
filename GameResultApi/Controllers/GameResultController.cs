using GameResultApi.Helpers;
using GameResultApi.Infrastructure.Enum;
using GameResultApi.Infrastructure.Request;
using GameResultApi.Infrastructure.Response;
using GameResultApi.Repositories;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System;

namespace GameResultApi.Controllers
{
    public class GameResultController : ApiController
    {
        #region Attributes
        private const string invalidParamters = "Invalid Parameters";
        private const string internalError = "Internal Error";
        private readonly IGameResultRepository gameResultRepository;
        #endregion

        #region Construct

        public GameResultController()
        {
            gameResultRepository = new GameResultRepository();
        }
        #endregion

        [HttpPost]
        [Route("GameResult/AddScore")]
        [ResponseType(typeof(string))]
        /// <summary>
        /// Function to Insert the GameResult for Registed User
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<IHttpActionResult> AddScoreAsync(string name, int score)
        {
            GameResultRQ request = new GameResultRQ()
            {
                UserName = name,
                Score = score
            };
            try
            {
                GameResultRS response = new GameResultRS();

                if (!string.IsNullOrEmpty(name))
                {
                    response = await gameResultRepository.Add(request);
                }
                else
                {
                    response.TransactionStatus = TransactionStatusHelper.CreateTransaction(HttpStatusCode.BadRequest.ToString(), invalidParamters, EndTransactionType.Error, ErrorType.ExternalError);
                }

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
