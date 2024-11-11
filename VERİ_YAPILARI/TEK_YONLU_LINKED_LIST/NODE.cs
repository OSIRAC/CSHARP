using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEK_YONLU_LINKED_LIST
{
    internal class NODE
    {

        public int data { get; set; }
        public NODE next { get; set; }

        public NODE(int data)
        {
            this.data = data;
            next = null;
        }

    }
}
