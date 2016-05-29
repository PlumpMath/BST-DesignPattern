using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.DTOs
{
    [DataContract]
    public class NodeDto
    {
        public NodeDto(int key)
        {
            this.key = key;
        }
        [DataMember]
        public int key { get; set; }
        [DataMember]
        public NodeDto left { get; set; }
        [DataMember]
        public NodeDto right { get; set; }
    }
}