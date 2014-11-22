using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GoGlass.WebApi
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "leme")]
        public List<string> Leme;
        
        [DataMember(Name = "kennedy")]
        public List<string> Kennedy;
        
        [DataMember(Name = "frings")]
        public List<string> Frings;

        public Response()
        {
            Leme = new List<string>();
            Kennedy = new List<string>();
            Frings = new List<string>();
        }
    }
}