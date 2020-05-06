using System.Runtime.Serialization;

namespace GameResultApi.Infrastructure.Response
{
    [DataContract]
    public class LeaderBoardItem
    {
        [DataMember]
        public string UserName { get; set; }
        
        [DataMember]
        public int Score { get; set; }

    }
}