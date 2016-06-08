using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public abstract class BSTTraversal
    {
        protected TraversalAction action;
        public BSTTraversal(TraversalAction action)
        {
            this.action = action;
        }
        public abstract void traverse(Node node);
    }
}
