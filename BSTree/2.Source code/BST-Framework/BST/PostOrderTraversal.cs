using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class PostOrderTraversal : BSTTraversal
    {
        public PostOrderTraversal(TraversalAction action) : base(action)
        {
        }

        public override void traverse(Node node)
        {
            if (node.isEmpty()) return;

            traverse(node.getLeft());
            traverse(node.getRight());
            action.run(node);
        }
    }
}
