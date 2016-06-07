using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public interface NodeFactory
    {
        Node createEmptyNode();
        Node createNonEmptyNode(int key);
    }
}
