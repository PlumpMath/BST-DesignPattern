using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class EmptyNode : Node
    {
        private static EmptyNode instance = null;

        protected EmptyNode(int key) : base(key) { }
        protected EmptyNode() : base() { }
        public override int accept(NodeVisitor nodeVisitor)
        {
            return nodeVisitor.visit(this);
        }

        public static EmptyNode getInstance()
        {
            if (instance == null)
            {
                instance = new EmptyNode();
            }
            return instance;
        }

        public override bool isEmpty()
        {
            return true;
        }
    }
}
