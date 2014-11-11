using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace GoClass.WebApi
{
    [DataContract]
    public class PathResponse
    {
        [DataMember(Name = "Leme")]
        public IList<string> salasLeme { get; set; }

        [DataMember(Name = "Kennedy")]
        public IList<string> salasKennedy { get; set; }

        [DataMember(Name = "Frings")]
        public IList<string> salasFrings { get; set; }
    }
}