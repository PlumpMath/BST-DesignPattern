using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeMinimumDeletionVisitor : NodeVisitor
    {
        public object visit(EmptyNode emptyNode)
        {
            return emptyNode;
        }

        public object visit(NonEmptyNode nonEmptyNode)
        {
            if (nonEmptyNode.getLeft().isEmpty()) return nonEmptyNode.getRight();

            nonEmptyNode.setLeft((Node)nonEmptyNode.getLeft().accept(this));

            return nonEmptyNode;
        }
    }
}
