using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinarySearchTree
{
    public partial class binarySearchTree : Form
    {
        Node root=null;
        public binarySearchTree()
        {
            InitializeComponent();
        }
        public Node find(int k)
        {
            Node z = root;
            while (z != null)
            {
                if (z.key == k)
                    return z;
                else
                {
                    if (k < z.key)
                        z = z.left;
                    else
                        z = z.right;
                }
            }
            return null;//not found
        }
        public Node find_parent(int k)
        {
            Node z = root;
            Node y = null;
            while (z != null)
            {
                y = z;
                if (z.key == k)
                    return z;
                else
                {
                    if (k < z.key)
                        z = z.left;
                    else
                        z = z.right;
                }
            }
            return y;//not found, return parent 
        }
        public void Add(int key)
        {
            Node newNode = new Node(key, null, null);
            if (root == null)
                root = newNode;
            else
            {
                Node parent = find_parent(key);
                newNode.parent = parent;
                if (key > parent.key)
                    parent.right = newNode;
                else if (key < parent.key)
                    parent.left = newNode;
                else
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("the value already exists");
                }
            }
        }
        public void PrintTree(Node node)
        {
            
            if (node != null)
            {
                PrintTree(node.left);
                listBox1.Items.Add(node.key.ToString() + " ");
                PrintTree(node.right);
            }
        }
        public void Delete(int key)
        {
            Node node = find(key);
            if (node != null)
            {
                if (node.right == null)
                {
                    if (node.parent.left.key == node.key)
                        node.parent.left = node.left;
                    else
                        node.parent.right = node.left;
                }
                else if (node.left == null)
                {
                    if (node.parent.left.key == node.key)
                        node.parent.left = node.right;
                    else
                        node.parent.right = node.right;
                }
                else//he has 2 sons
                {
                    //find the successor
                    Node succ = node.right;
                    while (succ.left != null)
                        succ = succ.left;
                    node.key = succ.key;//replace the value between the successor and node
                    //delete the successoe
                    if (succ.right == null)
                    {
                        if (succ.parent.left.key == succ.key)
                            succ.parent.left = succ.left;
                        else
                            succ.parent.right = succ.left;
                    }


                }
                MessageBox.Show("the value deleted");

            }
            else
                MessageBox.Show("the value not found");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Add(int.Parse(numericUpDown1.Value.ToString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            PrintTree(root);
            //BTreePrinter.Print(root);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Node z=find(int.Parse(numericUpDown2.Value.ToString()));
            listBox1.Items.Clear();
            if (z != null)
                listBox1.Items.Add("the value found :) ");
            else
                listBox1.Items.Add("the value not found :( ");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete(int.Parse(numericUpDown3.Value.ToString()));
        }
    }
}
