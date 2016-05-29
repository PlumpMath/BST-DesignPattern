using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = new int[11] { 5, 10, 21, 35, 47, 59, 60, 64, 76, 82, 99 };
            BSTree BST = new BSTree(Array);
            Console.Write("Array: ");
            for (int i = 0; i < 11; i++ )
            {
                Console.Write(Array[i] + " ");
            }
            Console.Write("\n");

            Console.Write("PreOrderTraversal: ");
            BST.traverse(new PreOrderTraversal());
            Console.Write("\n");

            Console.Write("InOrderTraversal: ");
            BST.traverse(new InOrderTraversal());
            Console.Write("\n");

            Console.Write("PostOrderTraversal: ");
            BST.traverse(new PostOrderTraversal());
            Console.Write("\n");

            Console.WriteLine("---------------------------");

            Console.Write("Number of Leaves: " + BST.numberOfLeaves() + "\n");
            Console.Write("Number of Nodes: " + BST.numberOfNodes(NodeState.ALL) + "\n");
            Console.Write("Number of Nodes has only 1 child: " + BST.numberOfNodes(NodeState.HAVING_ONLY_ONE_CHILD) + "\n");
            Console.Write("Number of Nodes has both children: " + BST.numberOfNodes(NodeState.HAVING_BOTH_CHILDREN) + "\n");
            Console.Write("Number of Nodes has only left child: " + BST.numberOfNodes(NodeState.HAVING_ONLY_LEFT_CHILD) + "\n");
            Console.Write("Number of Nodes has only right child: " + BST.numberOfNodes(NodeState.HAVING_ONLY_RIGHT_CHILD) + "\n");
            Console.Write("Tree's hight: " + BST.findHeight() + "\n");

            for (int i = 0; i < BST.findHeight(); i++)
                Console.Write("Level " + i + " has " + BST.numberOfNodesAtLevel(i) + " nodes \n");
            int x;
            Console.Write("Enter a key value: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("The path from root to " + x + " is " + BST.findPathLengthToX(x) + "\n");
            Console.ReadKey();
        }
    }
}
