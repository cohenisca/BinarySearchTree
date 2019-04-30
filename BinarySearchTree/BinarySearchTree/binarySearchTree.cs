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
                    node = node.left;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //numericUpDown1.Visible = true;
            //label1.Visible = true;
            Add(int.Parse(numericUpDown1.Value.ToString()));
            //numericUpDown1.Visible = false;
            //label1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            PrintTree(root);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //numericUpDown2.Visible = true;
            //label2.Visible = true;
            Node z=find(int.Parse(numericUpDown2.Value.ToString()));
            listBox1.Items.Clear();
            if (z != null)
                listBox1.Items.Add("the value found :) ");
            else
                listBox1.Items.Add("the value not found :( ");
            //numericUpDown2.Visible = false;
            //label2.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
