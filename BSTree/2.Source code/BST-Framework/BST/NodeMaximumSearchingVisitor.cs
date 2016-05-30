using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeMaximumSearchingVisitor : NodeVisitor
    {
        public object visit(EmptyNode emptyNode)
        {
            return emptyNode;
        }

        public object visit(NonEmptyNode nonEmptyNode)
        {
            if(nonEmptyNode.getRight().isEmpty())
            {
                return nonEmptyNode;
            }

            return nonEmptyNode.getRight().accept(this);
        }
    }
}
