using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeCountingVisitor : NodeVisitor
    {
        NodeCountingCondition condition;

        public NodeCountingVisitor(NodeCountingCondition condition)
        {
            this.condition = condition;
        }
        public int visit(EmptyNode emptyNode)
        {
            return 0;
        }

        public int visit(NonEmptyNode nonEmptyNode)
        {
            int count = 0;
            if (condition.apply(nonEmptyNode))
                count = 1;
            return count + (int)nonEmptyNode.getLeft().accept(this) + (int)nonEmptyNode.getRight().accept(this);
        }
    }
}
