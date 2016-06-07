using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        class NodeInterceptorImpl : NodeInterceptor
        {
            public void postHandle(Node node)
            {
                Console.WriteLine(node.getKey());
            }

            public void preHandle(Node node)
            {
                Console.WriteLine(node.getKey());
            }
        }
        static void Main(string[] args)
        {
            int[] a = new int[] { 3, 5, 8, 10, 12, 13, 18, 22, 30 };

            BSTree BST = new BSTree();
           

            InterceptableNodeFactory f = InterceptableNodeFactory.getInstance();
            f.setNodeInterceptor(new NodeInterceptorImpl());

            BST.setNodeFactory(f);

            BST.buildFromArray(a);
            BST.insert(44);
            

            //Console.Write("Array: ");
            //for (int i = 0; i < 11; i++ )
            //{
            //    Console.Write(a[i] + " ");
            //}
            //Console.Write("\n");

            //Console.Write("PreOrderTraversal: ");
            //BST.traverse(new PreOrderTraversal());
            //Console.Write("\n");

            //Console.Write("InOrderTraversal: ");
            //BST.traverse(new InOrderTraversal());
            //Console.Write("\n");

            //Console.Write("PostOrderTraversal: ");
            //BST.traverse(new PostOrderTraversal());
            //Console.Write("\n");

            //Console.WriteLine("---------------------------");

            //Console.Write("Number of Leaves: " + BST.numberOfLeaves() + "\n");
            //Console.Write("Number of Nodes: " + BST.numberOfNodes(NodeState.ALL) + "\n");
            //Console.Write("Number of Nodes has only 1 child: " + BST.numberOfNodes(NodeState.HAVING_ONLY_ONE_CHILD) + "\n");
            //Console.Write("Number of Nodes has both children: " + BST.numberOfNodes(NodeState.HAVING_BOTH_CHILDREN) + "\n");
            //Console.Write("Number of Nodes has only left child: " + BST.numberOfNodes(NodeState.HAVING_ONLY_LEFT_CHILD) + "\n");
            //Console.Write("Number of Nodes has only right child: " + BST.numberOfNodes(NodeState.HAVING_ONLY_RIGHT_CHILD) + "\n");
            //Console.Write("Tree's hight: " + BST.findHeight() + "\n");

            //for (int i = 0; i < BST.findHeight(); i++)
            //    Console.Write("Level " + i + " has " + BST.numberOfNodesAtLevel(i) + " nodes \n");
            //int x;
            //Console.Write("Enter a key value to find path: ");
            //x = int.Parse(Console.ReadLine());
            //int pathlength = BST.findPathLengthToX(x);
            //if (pathlength != -1)
            //Console.Write("The path from root to " + x + " is " + pathlength + "\n");
            //else Console.WriteLine(x + " doesn't exists!");

            //Console.Write("Enter a key value to find: ");
            //x = int.Parse(Console.ReadLine());
            //if(BST.findX(x) == null)
            //{
            //    Console.WriteLine(x + " doesn't exists!");
            //}
            //else Console.WriteLine(x +" exists!");

            //Console.WriteLine("Minimum node: " + BST.minimum());
            //Console.WriteLine("maximum node: " + BST.minimum());
            //Console.WriteLine("Minimum node of right child: " + BST.minimumOfRightChild());
            //Console.WriteLine("Maximum node of left child: " + BST.maximumOfLeftChild());

            //Console.Write("Enter a key value to delete: ");
            //x = int.Parse(Console.ReadLine());
            //BST.delete(x);
            //Console.Write("PreOrderTraversal: ");
            //BST.traverse(new PreOrderTraversal());
            //Console.Write("\n");

            Console.ReadKey();
        }
    }
}
