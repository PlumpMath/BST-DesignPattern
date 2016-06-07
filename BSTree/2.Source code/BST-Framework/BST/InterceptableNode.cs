using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class InterceptableNode : NonEmptyNode
    {
        private NodeInterceptor interceptor;
        public InterceptableNode(int key) : base(key)
        {
        }

        public InterceptableNode(int key, NodeInterceptor interceptor) : base(key)
        {
            this.interceptor = interceptor;
        }

        public override object accept(NodeVisitor nodeVisitor)
        {
            interceptor.preHandle(this);
            Object o = nodeVisitor.visit(this);
            interceptor.postHandle(this);
            return o;
        }

        public override bool isEmpty()
        {
            return false;
        }
    }
}
