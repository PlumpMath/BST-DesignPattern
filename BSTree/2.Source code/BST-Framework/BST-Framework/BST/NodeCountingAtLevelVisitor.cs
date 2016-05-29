using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeCountingAtLevelVisitor : NodeVisitor
    {
        int levelBeingCountedAt;
        int currentLevel;

        public NodeCountingAtLevelVisitor(int level)
        {
            this.levelBeingCountedAt = level;
            this.currentLevel = 0;
        }
        public int visit(EmptyNode emptyNode)
        {
            return 0;
        }

        public int visit(NonEmptyNode nonEmptyNode)
        {
            if(currentLevel < levelBeingCountedAt)
            {
                this.currentLevel++;
                int left = (int)nonEmptyNode.getLeft().accept(this);
                int right = (int)nonEmptyNode.getRight().accept(this);
                currentLevel--;

                return left + right;
            }
            return 1;
        }
    }
}
