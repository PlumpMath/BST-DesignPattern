using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public interface NodeVisitor
    {
        int visit(EmptyNode emptyNode);
        int visit(NonEmptyNode nonEmptyNode);
    }
}
