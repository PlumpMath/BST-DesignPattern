using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeCountingCondition
    {
        NodeState state;

        public NodeCountingCondition(NodeState state)
        {
            this.state = state;
        }
        public bool apply(Node node)
        {
            switch(state)
            {
                case NodeState.ALL:
                    return true;
                case NodeState.HAVING_BOTH_CHILDREN:
                    return NodeChecker.havingBothChildren(node);
                case NodeState.HAVING_ONLY_LEFT_CHILD:
                    return NodeChecker.havingOnlyLeftChild(node);
                case NodeState.HAVING_ONLY_ONE_CHILD:
                    return NodeChecker.havingOnlyOneChild(node);
                case NodeState.HAVING_ONLY_RIGHT_CHILD:
                    return NodeChecker.havingOnlyRightChild(node);
            }
            return false;
        }
    }
}
