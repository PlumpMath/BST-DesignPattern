using BST.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeInsertVisitor : NodeVisitor
    {
        int newKey;

        public NodeInsertVisitor(int newKey)
        {
            this.newKey = newKey;
        }
        public object visit(EmptyNode emptyNode)
        {
            NonEmptyNode newNode = (NonEmptyNode)BSTBuilder.getNodeFactory().createNonEmptyNode(newKey);
            newNode.setLeft(EmptyNode.getInstance());
            newNode.setRight(EmptyNode.getInstance());
            return newNode;
        }

        public object visit(NonEmptyNode nonEmptyNode)
        {
            if (newKey.Equals(nonEmptyNode.getKey()))
            {
                throw new KeyAlreadyExistException(newKey + " already exists");
            }
            if (newKey < nonEmptyNode.getKey())
                nonEmptyNode.setLeft((NonEmptyNode)nonEmptyNode.getLeft().accept(this));
            else nonEmptyNode.setRight((NonEmptyNode)nonEmptyNode.getRight().accept(this));

            return nonEmptyNode;
        }
    }
}
