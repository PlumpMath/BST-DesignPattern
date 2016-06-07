using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class NodeFactoryImpl : NodeFactory
    {
        private static NodeFactoryImpl instance = new NodeFactoryImpl();
        private NodeFactoryImpl() { }
        public static NodeFactoryImpl getInstance() { return instance; }

        public Node createEmptyNode()
        {
            return EmptyNode.getInstance();
        }

        public Node createNonEmptyNode(int key)
        {
            return new NonEmptyNode(key);
        }
    }
}
