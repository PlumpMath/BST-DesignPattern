using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.DTOs
{
    [DataContract]
    public class TreeInfo
    {
        [DataMember(Name = "number_of_leaves")]
        public int NumberOfLeaves { get; set; }

        [DataMember(Name = "number_of_nodes")]
        public NumberOfNodesWrapper NumberOfNodes { get; set; }

        [DataMember(Name = "height")]
        public int Height { get;  set;}

        [DataMember(Name = "at_level")]
        public int[] AtLevel { get; set; }

        [DataMember(Name = "min")]
        public int Min { get; set; }

        [DataMember(Name = "max")]
        public int Max { get; set; }

        [DataMember(Name = "min_of_right_child")]
        public int MinOfRightChild { get; set; }

        [DataMember(Name = "max_of_left_child")]
        public int MaxOfLeftChild { get; set; }

        [DataContract]
        public class NumberOfNodesWrapper
        {
            [DataMember(Name = "having_one_child")]
            public int HavingOneChild { get; set; }
            [DataMember(Name = "having_only_left_child")]
            public int HavingOnlyOneLeftChild { get; set; }
            [DataMember(Name = "having_only_right_child")]
            public int HavingOnlyOneRightChild { get; set; }
            [DataMember(Name = "having_both_children")]
            public int HavingBothChildren { get; set; }
            [DataMember(Name = "all")]
            public int All { get; set; }
        }

    }

    
}