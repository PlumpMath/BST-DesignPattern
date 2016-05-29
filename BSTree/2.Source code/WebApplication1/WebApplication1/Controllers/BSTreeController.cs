using BST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    public class BSTreeController : ApiController
    {
        [HttpPost]
        public NodeDto BuildTree([FromBody] int[] a)
        {
            BSTree tree = new BSTree(a);
            NodeDto dto = convert(tree.getRoot());
            return dto;
        }

        private NodeDto convert(Node node)
        {
            if (node.isEmpty()) return null;

            NodeDto dto = new NodeDto(node.getKey());

            dto.left = convert(node.getLeft());
            dto.right = convert(node.getRight());

            return dto;
        }
    }
}
