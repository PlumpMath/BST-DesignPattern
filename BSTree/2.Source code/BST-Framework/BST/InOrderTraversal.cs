using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class InOrderTraversal : BSTTraversal
    {
        public InOrderTraversal(TraversalAction action) : base(action)
        {
        }

        public override void traverse(Node node)
        {
            if (node.isEmpty()) return;
          
            traverse(node.getLeft());
            action.run(node);
            traverse(node.getRight());
        }
    }
}
