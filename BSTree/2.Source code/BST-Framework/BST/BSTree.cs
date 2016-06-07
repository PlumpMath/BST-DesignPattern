using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class BSTree
    {
        public Node root { get; set; }

        public BSTree()
        {
            root = EmptyNode.getInstance();
        }
        public BSTree(Node root)
        {
            this.root = root;
        }
        public BSTree(int[] a)
        {
            a = a.Distinct().ToArray();
            root = new NonEmptyNode(a[0]);
            root.setLeft(EmptyNode.getInstance());
            root.setRight(EmptyNode.getInstance());
            for (int i = 1; i < a.Length; i++)
            {
                insert(a[i]);
            }
        }
        public BSTree(int[] a, bool isBalancedTree)
        {
            a = a.Distinct().ToArray();
            if (isBalancedTree)
            {
                Array.Sort(a);
                root = BSTBuilder.sortedArrayToBST(a, 0, a.Length - 1);
            }
            else
            {
                root = new NonEmptyNode(a[0]);
                root.setLeft(EmptyNode.getInstance());
                root.setRight(EmptyNode.getInstance());
                for (int i = 1; i < a.Length; i++)
                {
                    insert(a[i]);
                }
            }
        }

        public void buildFromArray(int[] a)
        {
            Array.Sort(a);
            root = BSTBuilder.sortedArrayToBST(a, 0, a.Length - 1);
        }

        public void setNodeFactory(NodeFactory factory)
        {
            BSTBuilder.setNodeFactory(factory);
        }

        public void traverse(BSTTraversal traversalType)
        {
            traversalType.traverse(root);
        }

        public int numberOfLeaves()
        {
            return (int)root.accept(new LeafCountingVisitor());
        }

        public int numberOfNodes(NodeCountingCondition condition)
        {
            return (int)root.accept(new NodeCountingVisitor(condition));
        }

        public int numberOfNodes(NodeState state)
        {
            return numberOfNodes(new NodeCountingCondition(state));
        }

        public int findPathLengthToX(int x)
        {
            return (int)root.accept(new PathLengthFindingVisitor(x));
        }

        public int findHeight()
        {
            return (int)root.accept(new NodeHeightFindingVisitor());
        }

        public int numberOfNodesAtLevel(int level)
        {
            return (int)root.accept(new NodeCountingAtLevelVisitor(level));
        }

        public Node findX(int x)
        {
            Node result = (Node)root.accept(new NodeSearchingVisitor(x));
            return result.isEmpty() ? null : result;
        }

        public int minimum()
        {
            return ((Node)root.accept(new NodeMinimumSearchingVisitor())).getKey();
        }

        public int maximum()
        {
            return ((Node)root.accept(new NodeMaximumSearchingVisitor())).getKey();
        }

        public int maximumOfLeftChild()
        {
            return ((Node)root.getLeft().accept(new NodeMaximumSearchingVisitor())).getKey();
        }

        public int minimumOfRightChild()
        {
            return ((Node)root.getRight().accept(new NodeMinimumSearchingVisitor())).getKey();
        }

        public void delete(int x)
        {
            root = (Node)root.accept(new NodeDeletionVisitor(x));
        }

        public void insert(int newKey)
        {
            root = (Node)root.accept(new NodeInsertVisitor(newKey));
        }
    }
}
