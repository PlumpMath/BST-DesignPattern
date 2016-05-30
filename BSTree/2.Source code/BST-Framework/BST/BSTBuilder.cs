using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class BSTBuilder
    {
        public static Node sortedArrayToBST(int[] a, int start, int end)
        {
            if (start > end)
                return EmptyNode.getInstance();
            int mid = (start + end) / 2;
            Node root = new NonEmptyNode(a[mid]);

            root.setLeft(sortedArrayToBST(a, start, mid - 1));
            root.setRight(sortedArrayToBST(a, mid + 1, end));

            return root;
        }

    }
}
