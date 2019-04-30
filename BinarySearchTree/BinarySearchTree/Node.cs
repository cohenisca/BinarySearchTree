using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node
    {
        public int key { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node(int k,Node l=null,Node r=null)
        {
            key = k;
            left = l;
            right = r;
        }
    }
}
