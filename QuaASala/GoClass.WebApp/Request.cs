using System.Runtime.Serialization;

namespace GoGlass.WebApp
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