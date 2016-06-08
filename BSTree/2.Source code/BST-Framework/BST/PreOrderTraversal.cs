using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class PreOrderTraversal : BSTTraversal
    {
        public PreOrderTraversal(TraversalAction action) : base(action)
        {
        }

        public override void traverse(Node node)
        {
            if (node.isEmpty()) return;

            action.run(node);
            traverse(node.getLeft());
            traverse(node.getRight());
        }
    }
}
