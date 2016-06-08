using BST;
using BST.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.DTOs;
using static WebApplication1.DTOs.TreeInfo;

namespace WebApplication1.Controllers
{
   
    [RoutePrefix("api/bstree")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BSTreeController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "WELCOME TO BST API";
        }

        [HttpPost]
        public RestTemplate BuildTree([FromBody] int[] a)
        {
            if (a == null || a.Length == 0)
            {
                return new RestTemplate((int)HttpStatusCode.InternalServerError, null, "An array of integers is required to build a tree");
            }
            BSTree tree = new BSTree(a, true);
            NodeDto dto = toDto(tree.root, 1, 0);
            return new RestTemplate((int)HttpStatusCode.OK, dto, "");
        }

        [HttpPost]
        [Route("tree_info")]
        public RestTemplate GetTreeInfo([FromBody] NodeDto root)
        {
            BSTree tree = new BSTree(toEntity(root, NodeFactoryImpl.getInstance()));

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
            treeInfo.Height = tree.findHeight();
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
            BSTree tree = new BSTree(toEntity(root, NodeFactoryImpl.getInstance()));
            int length = tree.findPathLengthToX(x);
            string message = "";
            if (length == -1)
                message = x + " doesn't exist";

            return new RestTemplate((int)HttpStatusCode.OK, length, message);
        }

        [Route("max")]
        [HttpPost]
        public RestTemplate GetMax([FromBody] NodeDto root)
        {
            BSTree tree = new BSTree();
            List<int> turnTo = new List<int>();
            InterceptableNodeFactory.getInstance().setNodeInterceptor(new NodeInterceptorImpl(turnTo));
            tree.setNodeFactory(InterceptableNodeFactory.getInstance());
            tree.root = toEntity(root, InterceptableNodeFactory.getInstance());

            int max = tree.maximum();
            turnTo.RemoveAt(turnTo.Count - 1);

            Dictionary<string, Object> dict = new Dictionary<string, object>();
            dict.Add("turnTo", turnTo);
            dict.Add("maximum", max);

            return new RestTemplate((int)HttpStatusCode.OK, dict, "");
        }

        [Route("maxOfLeft")]
        [HttpPost]
        public RestTemplate GetMaxOfLeft([FromBody] NodeDto root)
        {
            BSTree tree = new BSTree();
            List<int> turnTo = new List<int>();
            InterceptableNodeFactory.getInstance().setNodeInterceptor(new NodeInterceptorImpl(turnTo));
            tree.setNodeFactory(InterceptableNodeFactory.getInstance());
            tree.root = toEntity(root, InterceptableNodeFactory.getInstance());

            

            int max = tree.maximumOfLeftChild();
            if (turnTo.Count == 0)
            {
                return new RestTemplate((int)HttpStatusCode.Conflict, null, "This tree has no left child");
            }
            if (turnTo.Count > 0)
                turnTo.RemoveAt(turnTo.Count - 1);

            turnTo.Insert(0, 0);

            Dictionary<string, Object> dict = new Dictionary<string, object>();
            dict.Add("turnTo", turnTo);
            dict.Add("maxOfLeft", max);

            return new RestTemplate((int)HttpStatusCode.OK, dict, "");
        }

        [Route("min")]
        [HttpPost]
        public RestTemplate GetMin([FromBody] NodeDto root)
        {
            BSTree tree = new BSTree();
            List<int> turnTo = new List<int>();
            InterceptableNodeFactory.getInstance().setNodeInterceptor(new NodeInterceptorImpl(turnTo));
            tree.setNodeFactory(InterceptableNodeFactory.getInstance());
            tree.root = toEntity(root, InterceptableNodeFactory.getInstance());

            int min = tree.minimum();
            turnTo.RemoveAt(turnTo.Count - 1);

            Dictionary<string, Object> dict = new Dictionary<string, object>();
            dict.Add("turnTo", turnTo);
            dict.Add("min", min);

            return new RestTemplate((int)HttpStatusCode.OK, dict, "");
        }

        [Route("minOfRight")]
        [HttpPost]
        public RestTemplate GetMinOfRight([FromBody] NodeDto root)
        {
            BSTree tree = new BSTree();
            List<int> turnTo = new List<int>();
         
            InterceptableNodeFactory.getInstance().setNodeInterceptor(new NodeInterceptorImpl(turnTo));
            tree.setNodeFactory(InterceptableNodeFactory.getInstance());
            tree.root = toEntity(root, InterceptableNodeFactory.getInstance());

            int minOfRight = tree.minimumOfRightChild();

            if (turnTo.Count == 0)
            {
                return new RestTemplate((int)HttpStatusCode.Conflict, null, "This tree has no right child");
            }

            if (turnTo.Count > 0)
                turnTo.RemoveAt(turnTo.Count - 1);

            turnTo.Insert(0, 1);

            Dictionary<string, Object> dict = new Dictionary<string, object>();
            dict.Add("turnTo", turnTo);
            dict.Add("minOfRight", minOfRight);

            return new RestTemplate((int)HttpStatusCode.OK, dict, "");
        }

        [Route("find")]
        [HttpPost]
        public RestTemplate FindX([FromBody] NodeDto root, int x)
        {
            BSTree tree = new BSTree();
            List<int> turnTo = new List<int>();
            InterceptableNodeFactory.getInstance().setNodeInterceptor(new NodeInterceptorImpl(turnTo));
            tree.setNodeFactory(InterceptableNodeFactory.getInstance());
            tree.root = toEntity(root, InterceptableNodeFactory.getInstance());

            tree.findX(x);
            turnTo.RemoveAt(turnTo.Count - 1);

            Dictionary<string, Object> dict = new Dictionary<string, object>();
            dict.Add("turnTo", turnTo);

            return new RestTemplate((int)HttpStatusCode.OK, dict, "");
        }

        [Route("traverse")]
        [HttpPost]
        public RestTemplate Traverse([FromBody] NodeDto root, string type)
        {
            BSTree tree = new BSTree(toEntity(root, NodeFactoryImpl.getInstance()));
            List<int> turnTo = new List<int>();

            BSTTraversal traversal = null;
            TraversalAction action = new TraversalActionImpl(turnTo);
            if (type.Equals("preOrder"))
            {
                traversal = new PreOrderTraversal(action);
            }
            else if (type.Equals("inOrder"))
            {
                traversal = new InOrderTraversal(action);
            }
            else if (type.Equals("postOrder"))
            {
                traversal = new PostOrderTraversal(action);
            }
            else
            {
                return new RestTemplate((int)HttpStatusCode.BadRequest, null, "preOrder or inOrder or postOrder is required for type");
            }

            tree.traverse(traversal);

            return new RestTemplate((int)HttpStatusCode.OK, turnTo, "");

        }

        [Route("delete")]
        [HttpPost]
        public RestTemplate DeleteX([FromBody] NodeDto root, int x)
        {
            BSTree tree = new BSTree(toEntity(root, NodeFactoryImpl.getInstance()));

            if (tree.findX(x) == null)
            {
                return new RestTemplate((int)HttpStatusCode.Conflict, null, x + " is not found");
            }

            tree.delete(x);
            return new RestTemplate((int)HttpStatusCode.OK, toDto(tree.root, 1, 0), "");
        }

        [Route("insert")]
        [HttpPost]
        public RestTemplate InsertX([FromBody] NodeDto root, int x)
        {
            BSTree tree = new BSTree();
            List<int> turnTo = new List<int>();
            InterceptableNodeFactory.getInstance().setNodeInterceptor(new NodeInterceptorImpl(turnTo));
            tree.setNodeFactory(InterceptableNodeFactory.getInstance());
            tree.root = toEntity(root, InterceptableNodeFactory.getInstance());
            
            //BSTree tree = new BSTree(toEntity(root));
            try
            {
                tree.insert(x);

                if (turnTo.Count > 0)
                {
                    if (x > turnTo[turnTo.Count - 1])
                        turnTo[turnTo.Count - 1] = 1;
                    else
                        turnTo[turnTo.Count - 1] = 0;
                }


                Dictionary<string, Object> dict = new Dictionary<string, object>();
                dict.Add("turnTo", turnTo);
                dict.Add("tree", toDto(tree.root, 1, 0));

                return new RestTemplate((int)HttpStatusCode.OK, dict, "");
            } 
            catch (KeyAlreadyExistException ex)
            {
                return new RestTemplate((int)HttpStatusCode.Conflict, toDto(tree.root, 1, 0), ex.Message);
            }
           
        }



        private NodeDto toDto(Node node, int order, int level)
        {
            if (node.isEmpty()) return null;

            NodeDto dto = new NodeDto(node.getKey(), order, level);

            dto.left = toDto(node.getLeft(), 2*order - 1, level + 1);
            dto.right = toDto(node.getRight(), 2*order, level + 1);

            return dto;
        }

        private Node toEntity(NodeDto dto, NodeFactory factory)
        {
            if (dto == null) return factory.createEmptyNode();

            Node node = factory.createNonEmptyNode(dto.key);
            node.setLeft(toEntity(dto.left, factory));
            node.setRight(toEntity(dto.right, factory));

            return node;
        }

        class NodeInterceptorImpl : NodeInterceptor
        {
            private List<int> turnTo;
            public NodeInterceptorImpl(List<int> turnTo)
            {
                this.turnTo = turnTo;
            }
            public void postHandle(Node node)
            {
            }

            public void preHandle(Node node)
            {
                if (turnTo.Count != 0)
                {
                    if (node.getKey() > turnTo[turnTo.Count - 1])
                    {
                        turnTo[turnTo.Count - 1] = 1;
                    }
                    else
                    {
                        turnTo[turnTo.Count - 1] = 0;
                    }
                }

               turnTo.Add(node.getKey());
            }
        }
        class TraversalActionImpl : TraversalAction
        {
            private List<int> turnTo;
            public TraversalActionImpl(List<int> turnTo)
            {
                this.turnTo = turnTo;
            }
            public void run(Node node)
            {
                turnTo.Add(node.getKey());
            }
        }
    }
}
