using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeSearchingVisitor : NodeVisitor
    {
        int x;

        public NodeSearchingVisitor(int x)
        {
            this.x = x;
        }
        public object visit(EmptyNode emptyNode)
        {
            return emptyNode;
        }

        public object visit(NonEmptyNode nonEmptyNode)
        {
            if(x == nonEmptyNode.getKey())
            {
                return nonEmptyNode;
            }
            if (x < nonEmptyNode.getKey())
            {
                return nonEmptyNode.getLeft().accept(this);
            }
            else return nonEmptyNode.getRight().accept(this);
        }
    }
}
