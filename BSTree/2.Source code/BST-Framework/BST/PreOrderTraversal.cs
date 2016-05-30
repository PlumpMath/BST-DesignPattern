using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class PreOrderTraversal : BSTTraversal
    {
        public void traverse(Node node)
        {
            if (node.isEmpty()) return;

            Console.Write(node.getKey() + " ");
            traverse(node.getLeft());
            traverse(node.getRight());
        }
    }
}
