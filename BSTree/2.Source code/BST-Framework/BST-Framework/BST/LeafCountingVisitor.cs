using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class LeafCountingVisitor : NodeVisitor
    {
        public int visit(EmptyNode emptyNode)
        {
            return 0;
        }

        public int visit(NonEmptyNode nonEmptyNode)
        {
            int numberOfLeaves = (int)nonEmptyNode.getLeft().accept(this) + (int)nonEmptyNode.getRight().accept(this);
            if (numberOfLeaves == 0) return 1;
            return numberOfLeaves;
        }
    }
}
