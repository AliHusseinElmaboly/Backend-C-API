﻿using System.Runtime.Serialization;

namespace GameResultApi.Infrastructure.Response
{
    [DataContract]
    public class UserRS : ObjectRS
    {

        [DataMember]
        public bool IsAdded { get; set; }
    }
}