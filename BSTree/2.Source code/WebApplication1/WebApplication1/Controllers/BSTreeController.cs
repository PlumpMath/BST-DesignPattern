using BST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DTOs;
using static WebApplication1.DTOs.TreeInfo;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/bstree")]
    public class BSTreeController : ApiController
    {
        [HttpPost]
        public RestTemplate BuildTree([FromBody] int[] a)
        {
            if (a == null)
            {
                return new RestTemplate((int)HttpStatusCode.InternalServerError, null, "An array of integers is required to build a tree");
            }
            BSTree tree = new BSTree(a, true);
            NodeDto dto = toDto(tree.root);
            return new RestTemplate((int)HttpStatusCode.OK, dto, "");
        }

        [HttpPost]
        [Route("tree_info")]
        public RestTemplate GetTreeInfo([FromBody] NodeDto root)
        {
            BSTree tree = new BSTree(toEntity(root));

            TreeInfo treeInfo = new TreeInfo();
            treeInfo.NumberOfLeaves = tree.numberOfLeaves();

            NumberOfNodesWrapper wrapper = new NumberOfNodesWrapper();
            wrapper.All = tree.numberOfNodes(NodeState.ALL);
            wrapper.HavingOneChild = tree.numberOfNodes(NodeState.HAVING_ONLY_ONE_CHILD);
            wrapper.HavingOnlyOneLeftChild = tree.numberOfNodes(NodeState.HAVING_ONLY_LEFT_CHILD);
            wrapper.HavingOnlyOneRightChild = tree.numberOfNodes(NodeState.HAVING_ONLY_RIGHT_CHILD);
            wrapper.HavingBothChildren = tree.numberOfNodes(NodeState.HAVING_BOTH_CHILDREN);

            treeInfo.NumberOfNodes = wrapper;

            int[] LevelAndNodeCount = new int[tree.findHeight()];
            for (int i = 0; i < tree.findHeight(); i++)
            {
                LevelAndNodeCount[i] = tree.numberOfNodesAtLevel(i);
            }
            treeInfo.AtLevel = LevelAndNodeCount;

            treeInfo.Min = tree.minimum();
            treeInfo.Max = tree.maximum();
            treeInfo.MinOfRightChild = tree.minimumOfRightChild();
            treeInfo.MaxOfLeftChild = tree.maximumOfLeftChild();

            return new RestTemplate((int)HttpStatusCode.OK, treeInfo, "");
        }

        [Route("path_length")]
        [HttpPost]
        public RestTemplate GetPathLengthToX([FromBody] NodeDto root, int x)
        {
            BSTree tree = new BSTree(toEntity(root));
            int length = tree.findPathLengthToX(x);
            string message = "";
            if (length == -1)
                message = x + " doesn't exist";

            return new RestTemplate((int)HttpStatusCode.OK, length, message);
        }

        private NodeDto toDto(Node node)
        {
            if (node.isEmpty()) return null;

            NodeDto dto = new NodeDto(node.getKey());

            dto.left = toDto(node.getLeft());
            dto.right = toDto(node.getRight());

            return dto;
        }

        private Node toEntity(NodeDto dto)
        {
            if (dto == null) return EmptyNode.getInstance();

            Node node = new NonEmptyNode(dto.key);
            node.setLeft(toEntity(dto.left));
            node.setRight(toEntity(dto.right));

            return node;
        }
    }
}
