using BST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : ApiController
    {
        //[Route("nodes")]
        //public String Get(String q1, String q2)
        //{
        //    BSTree tree = new BSTree(new int[] { 3, 5, 8, 10, 12, 13, 18, 22, 30 });
        //    NodeDto node = new NodeDto(1);
        //    NodeDto node2 = new NodeDto(2);
        //    NodeDto node3 = new NodeDto(3);
        //    node.left = node2;
        //    node.right = node3;


            
        //    return q1 + q2;
        //}

        [HttpPost]
        public String[] Post([FromBody]String[] values)
        {
            return values;
        }
    }
}
