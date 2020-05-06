using System.Runtime.Serialization;

namespace GameResultApi.Infrastructure.Request
{
    [DataContract]
    public class GameResultRQ
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public int Score { get; set; }

    }
}