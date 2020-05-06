using System.Runtime.Serialization;

namespace GameResultApi.Infrastructure.Request
{
    [DataContract]
    public class UserRQ
    {

        public UserRQ()
        {

        }

        [DataMember]
        public string UserName { get; set; }

    }
}