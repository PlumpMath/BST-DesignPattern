using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class BSTBuilder
    {
        private static NodeFactory factory = NodeFactoryImpl.getInstance();
        public static NodeFactory getNodeFactory()
        {
            return factory;
        }
        public static void setNodeFactory(NodeFactory factory)
        {
            BSTBuilder.factory = factory;
        }
        public static Node sortedArrayToBST(int[] a, int start, int end)
        {
            if (start > end)
                return factory.createEmptyNode();
            int mid = (start + end) / 2;
            Node root = factory.createNonEmptyNode(a[mid]);

            root.setLeft(sortedArrayToBST(a, start, mid - 1));
            root.setRight(sortedArrayToBST(a, mid + 1, end));

            return root;
        }

    }
}
