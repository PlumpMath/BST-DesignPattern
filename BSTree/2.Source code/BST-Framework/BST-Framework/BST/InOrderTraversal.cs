using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class InOrderTraversal : BSTTraversal
    {
        public void traverse(Node node)
        {
            if (node.isEmpty()) return;
          
            traverse(node.getLeft());
            Console.Write(node.getKey() + " ");
            traverse(node.getRight());
        }
    }
}
