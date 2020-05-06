using GameResultApi.Helpers;
using GameResultApi.Infrastructure.Request;
using System.Runtime.Serialization;

namespace GameResultApi.Infrastructure.Response
{
    [DataContract]
    public class ObjectRS
    {
        ///<summary>
        /// Constructor
        ///</summary>
        public ObjectRS()
        {
            TransactionStatus = TransactionStatusHelper.CreateTransaction();
        }

        /// <summary>
        /// response status
        /// </summary>
        [DataMember]
        public TransactionStatus TransactionStatus { get; set; }
    }
}