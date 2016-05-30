using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeChecker
    {
        public static bool havingOnlyOneChild(Node node)
        {
            if ((node.getRight().isEmpty() && !node.getLeft().isEmpty()) || (node.getLeft().isEmpty() && !node.getRight().isEmpty()))
                return true;
            else return false;
        }

        public static bool havingBothChildren(Node node)
        {
            if (!node.getRight().isEmpty() && !node.getLeft().isEmpty())
                return true;
            else return false;
        }

        public static bool havingOnlyLeftChild(Node node)
        {
            if (node.getRight().isEmpty() && !node.getLeft().isEmpty())
                return true;
            else return false;
        }

        public static bool havingOnlyRightChild(Node node)
        {
            if (!node.getRight().isEmpty() && node.getLeft().isEmpty())
                return true;
            else return false;
        }
    }
}
