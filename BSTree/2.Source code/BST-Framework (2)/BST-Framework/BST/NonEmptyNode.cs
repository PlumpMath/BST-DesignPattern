using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NonEmptyNode : Node
    {
        public NonEmptyNode(int key) : base(key){}
        public override object accept(NodeVisitor nodeVisitor)
        {
            return nodeVisitor.visit(this);
        }

        public override bool isEmpty()
        {
            return false;
        }
    }
}
