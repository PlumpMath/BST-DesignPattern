using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public interface NodeVisitor
    {
        object visit(EmptyNode emptyNode);
        object visit(NonEmptyNode nonEmptyNode);
    }
}
