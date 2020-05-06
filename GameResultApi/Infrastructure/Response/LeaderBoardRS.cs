using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameResultApi.Infrastructure.Response
{
    [DataContract]
    public class LeaderBoardRS : ObjectRS
    {
        [DataMember]
        public List<LeaderBoardItem> leaderBoardItems;
        public LeaderBoardRS()
        {
            leaderBoardItems = new List<LeaderBoardItem>();
        }
    }
} 