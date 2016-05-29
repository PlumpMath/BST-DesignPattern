using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.DTOs
{
    [DataContract]
    public class RestTemplate
    {
        public RestTemplate(int HttpStatus, Object Value, Object Message)
        {
            this.HttpStatus = HttpStatus;
            this.Value = Value;
            this.Message = Message;
        }
        [DataMember(Name = "http_status")]
        public int HttpStatus { get; set; }
        [DataMember(Name = "value")]
        public Object Value { get; set; }
        [DataMember(Name = "message")]
        public Object Message { get; set; }
    }
}