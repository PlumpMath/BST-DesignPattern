using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeDeletionVisitor : NodeVisitor
    {
        int x;
        public NodeDeletionVisitor(int x)
        {
            this.x = x;
        }
        public object visit(EmptyNode emptyNode)
        {
            Console.WriteLine(x + " doesn't exists!");
            return emptyNode;
        }

        public object visit(NonEmptyNode nonEmptyNode)
        {
            if(x < nonEmptyNode.getKey())
            {
                nonEmptyNode.setLeft((Node)nonEmptyNode.getLeft().accept(this));
            }
            else if(x > nonEmptyNode.getKey())
            {
                nonEmptyNode.setRight((Node)nonEmptyNode.getRight().accept(this));
            }
            else
            {
                if (nonEmptyNode.getLeft().isEmpty()) return nonEmptyNode.getRight();
                else if (nonEmptyNode.getRight().isEmpty()) return nonEmptyNode.getLeft();

                Node temp = nonEmptyNode;
                nonEmptyNode = (NonEmptyNode)temp.getRight().accept(new NodeMinimumSearchingVisitor());
                nonEmptyNode.setRight((Node)temp.getRight().accept(new NodeMinimumDeletionVisitor()));
                nonEmptyNode.setLeft(temp.getLeft());
            }
            return nonEmptyNode;
        } 
    }
}
