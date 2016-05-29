using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class PathLengthFindingVisitor : NodeVisitor
    {
        int x;
        int currentLengthPath;

        public PathLengthFindingVisitor(int x)
        {
            this.x = x;
        }
        public int visit(EmptyNode emptyNode)
        {
            return -1;
        }

        public int visit(NonEmptyNode nonEmptyNode)
        {
            if(nonEmptyNode.getKey() == x)
            {
                return currentLengthPath;
            }

            currentLengthPath++;
            int resultFromLeft = (int)nonEmptyNode.getLeft().accept(this);
            int resultFromRight = (int)nonEmptyNode.getRight().accept(this);
            currentLengthPath--;

            return resultFromLeft != -1 ? resultFromLeft : resultFromRight;
        }
    }
}
