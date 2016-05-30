using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public abstract class Node
    {

        protected Node left;
        protected Node right;
        protected int key;


        public Node(int key)
        {
            this.key = key;
        }

        protected Node() { }
        public Node getLeft()
        {
            return left;
        }
        public Node getRight()
        {
            return right;
        }

        public void setLeft(Node leftnode)
        {
            left = leftnode;
        }

        public void setRight(Node rightnode)
        {
            right = rightnode;
        }

        public int getKey()
        {
            return key;
        }
        abstract public object accept(NodeVisitor nodeVisitor);

        abstract public bool isEmpty();
    }
}
