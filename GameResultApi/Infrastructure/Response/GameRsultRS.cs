using System.Runtime.Serialization;

namespace GameResultApi.Infrastructure.Response
{
    [DataContract]
    public class GameResultRS : ObjectRS
    {

        [DataMember]
        public bool IsAdded { get; set; }
    }
}