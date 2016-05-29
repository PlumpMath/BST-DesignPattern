using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class BSTree
    {
        Node root;

        public BSTree(int[] a)
        {
            root = BSTBuilder.sortedArrayToBST(a, 0, a.Length - 1);
        }

        public Node getRoot()
        {
            return root;
        }

        public void traverse(BSTTraversal traversalType)
        {
            traversalType.traverse(root);
        }

        public int numberOfLeaves()
        {
            return root.accept(new LeafCountingVisitor());
        }

        public int numberOfNodes(NodeCountingCondition condition)
        {
            return root.accept(new NodeCountingVisitor(condition));
        }

        public int numberOfNodes(NodeState state)
        {
            return numberOfNodes(new NodeCountingCondition(state));
        }

        public int findPathLengthToX(int x)
        {
            return root.accept(new PathLengthFindingVisitor(x));
        }

        public int findHeight()
        {
            return root.accept(new NodeHeightFindingVisitor());
        }

        public int numberOfNodesAtLevel(int level)
        {
            return root.accept(new NodeCountingAtLevelVisitor(level));
        }
    }
}
