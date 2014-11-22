using System.Runtime.Serialization;

namespace GoGlass.WebApi
{
    [DataContract]
    public class Request
    {
        [DataMember(Name = "time")]
        public string Time;

        [DataMember(Name = "dayweek")]
        public string DayWeek;
    }
}