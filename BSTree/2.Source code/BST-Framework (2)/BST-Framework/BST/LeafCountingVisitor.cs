using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class LeafCountingVisitor : NodeVisitor
    {
        public object visit(EmptyNode emptyNode)
        {
            return 0;
        }

        public object visit(NonEmptyNode nonEmptyNode)
        {
            int numberOfLeaves = (int)nonEmptyNode.getLeft().accept(this) + (int)nonEmptyNode.getRight().accept(this);
            if (numberOfLeaves == 0) return 1;
            return numberOfLeaves;
        }
    }
}
