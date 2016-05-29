using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public enum NodeState
    {
        ALL,
        HAVING_ONLY_ONE_CHILD,
        HAVING_BOTH_CHILDREN,
        HAVING_ONLY_LEFT_CHILD,
        HAVING_ONLY_RIGHT_CHILD
    }
}
