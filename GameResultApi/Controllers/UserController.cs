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
    public class UserController : ApiController
    {
        #region Attributes
        private const string invalidParameters = "Invalid Parameters";
        private const string internalErrors = "Internal Error";

        private readonly IUserRepository userRepository;

        #endregion

        #region Construct
        public UserController()
        {
            userRepository = new UserRepository();
        }
        #endregion

        [HttpPost]
        [Route("user/registerUser")]
        [ResponseType(typeof(string))]
        /// <summary>
        /// Function to register user
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<IHttpActionResult> RegisterUserAsync(string name)
        {
            UserRQ request = new UserRQ()
            {
                UserName = name
            };
            try
            {
                UserRS response = new UserRS();

                if (!string.IsNullOrEmpty(name))
                {
                    response.IsAdded = await userRepository.Add(request);
                    if (!response.IsAdded)
                        response.TransactionStatus = TransactionStatusHelper.CreateTransaction(HttpStatusCode.BadRequest.ToString(), internalErrors, EndTransactionType.Error, ErrorType.ProgrammerError);
                }
                else
                {
                    response.TransactionStatus = TransactionStatusHelper.CreateTransaction(HttpStatusCode.BadRequest.ToString(), invalidParameters, EndTransactionType.Error, ErrorType.ExternalError);
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
