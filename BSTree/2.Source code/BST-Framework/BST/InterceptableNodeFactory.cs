using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class InterceptableNodeFactory : NodeFactory
    {
        private static InterceptableNodeFactory instance = new InterceptableNodeFactory();
        private InterceptableNodeFactory() { }

        public static InterceptableNodeFactory getInstance()
        {
            return instance;
        }

        private NodeInterceptor interceptor;
        public void setNodeInterceptor(NodeInterceptor interceptor)
        {
            this.interceptor = interceptor;
        }

        public Node createEmptyNode()
        {
            return EmptyNode.getInstance();
        }

        public Node createNonEmptyNode(int key)
        {
            return new InterceptableNode(key, interceptor);
        }
    }
}
