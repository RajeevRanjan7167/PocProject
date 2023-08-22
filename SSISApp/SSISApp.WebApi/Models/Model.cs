using Newtonsoft.Json;
using System.ComponentModel;

namespace SSISApp.WebApi.Models
{
    public class Model
    {
        public class BaseResponse
        {
            public string callerReferance { get; set; }
            public Notification notification { get; set; }
            public bool status { get; set; }
        }

        public class Response<T> : BaseResponse
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public T data { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public IEnumerable<T> list { get; set; }
        }

        public class Notification
        {
            public string code { get; set; }
            public NotificationType type { get; set; }
            public string description { get; set; }
            public string stackTrace { get; set; }
        }

        public enum NotificationType
        {
            [Description("Information")]
            Information = 1,

            [Description("Warning")]
            Warning = 2,

            [Description("Error")]
            Error = 3
        }
    }
}
