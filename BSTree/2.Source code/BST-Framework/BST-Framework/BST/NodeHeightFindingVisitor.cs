using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
    public class NodeHeightFindingVisitor : NodeVisitor
    {
        public int visit(EmptyNode emptyNode)
        {
            return 0;
        }

        public int visit(NonEmptyNode nonEmptyNode)
        {
            //tìm chiều cao của cây con trái và cây con phải,
            //cây con nào có chiều cao lớn hơn thì lấy giá trị đó cộng thêm 1(1 là chiều cao của nút gốc)
            return 1 + Math.Max((int)nonEmptyNode.getLeft().accept(this), (int)nonEmptyNode.getRight().accept(this));
        }
    }
}
