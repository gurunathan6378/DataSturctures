﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using OfficeOpenXml.Table.PivotTable;

namespace WindowsFormsApplication3
{
 
    public partial class LinkedListForm : Form
    {
        static int TWO_NODES_FOUND = 2;
        static int ONE_NODES_FOUND = 1;
        static int NO_NODES_FOUND = 0;

        StringBuilder datas = new StringBuilder();
        static int visited = 0;
        LinkList linkListNode = null;

        public LinkedListForm()
        {
            InitializeComponent();
        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            Node tree = null;                    
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(6, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(9, ref tree);
            datas.Clear();
            datas.Append("\r\n InOrder Traversal :");
            InOrder(tree);
            datas.Append("\r\n PreOrder Traversal :");
            PreOrder(tree);
            datas.Append("\r\n PostOrder Traversal :");
            PostORder(tree);
            datas.Append("\r\n BFS Traversal :");
            BFT(tree);
            MessageBox.Show(datas.ToString());

           }



        private Node Insert(int data, ref Node tree)
        {
            if (tree == null)
            {
                tree = new Node();
                tree.data = data;
            }
            else
            {
                if (data > tree.data)
                {
                    Insert(data, ref tree.right);
                }
                else if (data < tree.data)
                {
                    Insert(data, ref tree.left);
                }
            }

            return tree;
        }

        private Node InsertTreeNodeImproperly(int data, ref Node tree)
        {
            if (tree == null)
            {
                tree = new Node();
                tree.data = data;
            }
            else
            {
                if (data < tree.data)
                {
                    InsertTreeNodeImproperly(data, ref tree.right);
                }
                else if (data > tree.data)
                {
                    InsertTreeNodeImproperly(data, ref tree.left);
                }
            }

            return tree;
        }




        private NodeWithNext InsertNodeWithNext(int data, ref NodeWithNext tree)
        {
            if (tree == null)
            {
                tree = new NodeWithNext();
                tree.data = data;
            }
            else
            {
                if (data > tree.data)
                {
                    InsertNodeWithNext(data, ref tree.right);
                }
                else if (data < tree.data)
                {
                    InsertNodeWithNext(data, ref tree.left);
                }
            }

            return tree;
        }

        private void InsertBFSNode(int data, ref BFSNode tree, BFSNode parent)
        {
            if (tree == null)
            {
                tree = new BFSNode();
                tree.data = data;
                tree.parent = parent;
            }
            else
            {
                if (data > tree.data)
                {
                    InsertBFSNode(data, ref tree.right, tree);
                }
                else if (data < tree.data)
                {
                    InsertBFSNode(data, ref tree.left, tree);
                }
            }
            
        }


        private void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.left);
                datas.Append(node.data.ToString() + ",");
                InOrder(node.right);
            }
        }

        private void PreOrder(Node node)
        {
            if (node != null)
            {
                datas.Append(node.data.ToString() + ",");
                PreOrder(node.left);                
                PreOrder(node.right);
            }
        }

        private void PostORder(Node node)
        {
            if (node != null)
            {
                PostORder(node.left);
                PostORder(node.right);
                datas.Append(node.data.ToString() + ",");
            }
        }

        private void BFT(Node node)
        {

            Queue<Node> queue = new Queue<Node>();            
            Node currentNode = null;
            datas.Append(node.data.ToString() + ",");
            queue.Enqueue(node);
            //queue.Enqueue(null);

            while (true)
            {
                if (queue.Count == 0)
                {
                    break;
                }

                currentNode = queue.Dequeue() as Node;

                //This condition needed as queue will never be empty as we are always adding one element in the queue.      
                if (currentNode == null) break;
                
                if (currentNode != null)
                {
                    
                    if (currentNode.left != null)
                    {
                        datas.Append(currentNode.left.data.ToString() + ",");
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right!= null)
                    {
                        datas.Append(currentNode.right.data.ToString() + ",");
                        queue.Enqueue(currentNode.right);
                    }
                }                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int[] input = new Int32[11] { -1, 10, -2, 9, -3, 8, 0, -4, 7, -5, 6 };
            //int[] input = new Int32[11] { 1, 2, 3, 4, 5, 0, -1, -2, -3, -4, 5 };
            //int[] input = new Int32[11] { -1, -2, -3, -4, -1, -0, -1, -2, -3, -4, -5 };
            //int[] input = new Int32[11] { 1, 2, 3, 4, 1, 0, 1, 2, 3, 4, 5 };
            //int[] input = new Int32[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //int[] input = new Int32[11] { -1, 10, 0, -2, 9, -3, 8, -4, 7, -5, 6 };
            //Capturing inputs
            string[] result = textBox1.Text.Split(',');            
            int[] input = new Int32[result.Length];
            int t;
            for (int k = 0; k < result.Length; k++)
            {
                if (int.TryParse(result[k], out t))
                {
                    input[k] = t;
                }
            }
            //int[] input = new Int32[11] { -1, 10, 0, -2, 9, -3, 8, -4, 0, -5, 6 };
            int up = input.Length - 1;
            int down = 0;
            
            while (down < up)
            {
                t = 0;                
                if (input[down] >= 0 && input[up] <= 0 )
                {
                    t = input[down];
                    input[down] = input[up];
                    input[up] = t;
                    down++;
                    up--;
                }
                else if (input[down] >= 0 && input[up] >= 0)
                {
                    up--;                    
                }                
                else 
                {
                    down++;                    
                }                               
            }

            StringBuilder data = new StringBuilder();
            for (int j = 0; j < input.Length; j++)
            {
                data.Append(input[j]+ ",");
            }
            MessageBox.Show(data.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int[] input = new Int32[11] { -1, 10, -2, 9, -3, 8, 0, -4, 7, -5, 6 };
            //int[] input = new Int32[11] { 1, 2, 3, 4, 5, 0, -1, -2, -3, -4, 5 };
            //int[] input = new Int32[11] { -1, -2, -3, -4, -1, -0, -1, -2, -3, -4, -5 };
            //int[] input = new Int32[11] { 1, 2, 3, 4, 1, 0, 1, 2, 3, 4, 5 };
            //int[] input = new Int32[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //int[] input = new Int32[11] { -1, 10, 0, -2, 9, -3, 8, -4, 7, -5, 6 };
            //int[] input = new Int32[11] { -1, 10, 0, -2, 9, -3, 8, -4, 0, -5, 6 };
            //int[] input = new Int32[11] { -0, 10, 0, -2, 9, -3, 8, -4, 0, -5, 6 };
            //int[] input = new Int32[11] { 0, 10, 0, -2, 9, -3, 8, -4, 0, -5, 6 };

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Inputs required");
            }
            else
            {
                //Capturing inputs
                string[] result = textBox1.Text.Split(',');
                int t;
                int[] input = new Int32[result.Length];
                for (int k = 0; k < result.Length; k++)
                {
                    if (int.TryParse(result[k], out t))
                    {
                        input[k] = t;
                    }
                }

                //Logic to arrange –ve and +ve to left and write of zero respectively
                t = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[i] >= 0 && input[j] <= 0)
                        {
                            t = input[i];
                            input[i] = input[j];
                            input[j] = t;
                        }
                    }
                }

                //Displays the output
                StringBuilder data = new StringBuilder();
                for (int j = 0; j < input.Length; j++)
                {
                    data.Append(input[j] + ",");
                }
                MessageBox.Show(data.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BFSNode root = newNode(1);
            root.parent      = null;
            root.left         = newNode(2);
            root.right        = newNode(3);
            root.left.parent = root;
            root.right.parent = root;  

            root.left.left  = newNode(4);
            root.right.right = newNode(5); 

            root.left.left.parent   = root.left;
            root.right.right.parent  = root.right;

             // printf("\n Level order successor of %d is: ", root->right->data);
              printLevelOrderSuccessor(root.left);

        }

        
        void _print(BFSNode root, BFSNode temp, int level)
        {             
            if(root == null)
                return;
            if(level == 1)
            {
                /* If the given node is visited then print the current root */
                if(visited == 1)
                {
                    MessageBox.Show(root.data.ToString());
                    visited = 0;
                    return;
                }
                /* If the current root is same as given node then change the visited flag
                so that current node is printed */
                if (root == temp)
                {
                    visited = 1;
                }
            }
            else if (level > 1)
            {
                _print(root.left, temp, level-1);
                _print(root.right, temp, level - 1);
            }
        }

        void printLevelOrderSuccessor(BFSNode node)
        {
           int level = 1;
           BFSNode temp = node;

           /* Find the level of the given node and root of the tree */
           while(temp.parent != null)
           {
             temp = temp.parent;
             level++;
           }
           _print(temp, node, level);
        }

        private BFSNode newNode(int data)
        {
            BFSNode node = new BFSNode();
           node.data = data;
           node.left = null;
           node.right = null;
           node.parent = null;
           return(node);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LinkList LLNodeFirst= null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 7);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 9);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");
                        
            LinkList LLNodeSecond= null;
            LLNodeSecond = InsertLinkList(LLNodeSecond, 1);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 2);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 4);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 6);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 8);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 10);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 12);

            DisplayLinkList(LLNodeSecond);
            datas.Append("\n");

           
            DisplayLinkList(Merge(LLNodeSecond, LLNodeFirst));
            MessageBox.Show(datas.ToString());
        }

        private LinkList InsertLinkList(LinkList LLNode, int data)
        {
            if (LLNode == null)
            {
                LLNode = new LinkList();
                LLNode.data = data;
                LLNode.next = null;
                
            }
            else
            {
                LLNode.next = InsertLinkList(LLNode.next, data);
            }
            return LLNode;
        }

        private LinkListCharacter InsertLinkListForCharacter(LinkListCharacter node, char data)
        {
            if (node == null)
            {
                node = new LinkListCharacter();
                node.data = data;
                node.next = null;
            }
            else
            {
                node.next = InsertLinkListForCharacter(node.next, data);
            }
            return node;
        }

        private void DisplayLinkList(LinkList Node)
        {
            if (Node != null)
            {
                datas.Append(Node.data.ToString() + ",");
                DisplayLinkList(Node.next);
            }            
        }

        private LinkList Merge(LinkList first, LinkList second)
        {
            
            LinkList p = first;
            LinkList q = second;
            LinkList previous = new LinkList();
            LinkList returnList = previous;

            while (p != null && q != null)
            {
                if (p.data == q.data)
                {
                    previous.next = p;
                    p = p.next;
                    q = q.next;                    
                }
                else if (p.data < q.data)
                {
                    previous.next = p;
                    p = p.next;
                }
                else 
                {
                    previous.next = q;
                    q = q.next;
                }
                previous = previous.next;
            }

            while (p!=null)
            {
                previous.next = p;
                p = p.next;
                previous  = previous.next;
            }

            while (q != null)
            {
                previous.next = q;
                q = q.next;
                previous = previous.next;
            }

            return returnList.next;           

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 4);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 4);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 0);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 2);
            datas.Clear();
            DisplayLinkList(LLNodeFirst);            
            MessageBox.Show(datas.ToString());

            LinkList current, previous, next_next;
            current = LLNodeFirst;

            datas.Clear();

            //// Delete duplicate node from a sorted linked list
            ///* Traverse list till the last node */
            //while (current.next != null)
            //{
            //    /*Compare current node with the next node */
            //    if (current.data == current.next.data)
            //    {
            //        next_next = current.next.next;
            //        current.next = null;
            //        current.next = next_next;
            //    }
            //    else
            //        // advance if no deletion               
            //        current = current.next;
            //}

            //datas.Append("\n\n Time Complexity: O(n)");
            //DisplayLinkList(LLNodeFirst);
            //MessageBox.Show(datas.ToString());

            //4->4->5->1->0->11->1->2
            //Complexity is O(n^2)
            datas.Clear();
            previous = LLNodeFirst;
            current = previous.next;
            while (current != null)
            {
                LinkList runner = LLNodeFirst;
                while (runner != current)
                {
                    if (runner.data == current.data)
                    {
                        LinkList temp = current.next;
                        previous.next = temp;
                        current = temp;
                        break;
                    }
                    runner = runner.next;
                }

                if (current == runner)
                {
                    previous = current;
                    current = current.next;
                }
            }

            datas.Append("\n\n Time Complexity: O(n^2)");            
            DisplayLinkList(LLNodeFirst);
            MessageBox.Show(datas.ToString());





        }

        private void button7_Click(object sender, EventArgs e)
        {
            datas.Clear();
            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 7);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 9);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n\n");
            
            LinkList LLNodeSecond = null;
            LLNodeSecond = InsertLinkList(LLNodeSecond, 1);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 1);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 6);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 8);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 10);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 12);

            DisplayLinkList(LLNodeSecond);

            datas.Append("\n\n");

            LinkList LLNode = AddLinkList(LLNodeFirst, LLNodeSecond, 0);

            DisplayLinkList(LLNode);
            MessageBox.Show(datas.ToString());

        }

        private LinkList AddLinkList(LinkList l1, LinkList l2, int carry)
        {

            if (l1 == null && l2 == null && carry ==0)
                return null;

            LinkList result = new LinkList();
            if (l1 == null && l2 == null && carry > 0)
            {
                result.data = carry;
                return result;
            }

            int value = carry;
            
            if (l1!=null)
                value += l1.data;
             
            if (l2 != null)
                value += l2.data;

            //Mod reminder / quocent
            result.data = value % 10;

            LinkList more = AddLinkList(11 == null ? null : l1.next,
                                        l2 == null ? null : l2.next,
                                        value > 10 ? value/10 : 0);
            result.next = more;

            return result;


        }

        private void button8_Click(object sender, EventArgs e)
        {
            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            //Insert(15, ref tree);
            //Insert(22, ref tree);
            string max = MaxDepthOfTheTree(tree).ToString();
            string min = MinDepthOfTheTree(tree).ToString();    
            MessageBox.Show("Max = " + max + " Min = " + min);           
        }

        private int MaxDepthOfTheTree(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + Math.Max(MaxDepthOfTheTree(node.left), MaxDepthOfTheTree(node.right));
        }


        private int MinDepthOfTheTree(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + Math.Min(MinDepthOfTheTree(node.left), MinDepthOfTheTree(node.right));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);

            int level = 0;
            


        }

        private void button10_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/inorder-successor-in-binary-search-tree/
            // Time Complexity: O(h) where h is height of tree.
            BFSNode tree = null;
            InsertBFSNode(10, ref tree,tree);
            InsertBFSNode(5, ref tree, tree);
            InsertBFSNode(20, ref tree, tree);
            InsertBFSNode(3, ref tree, tree);
            InsertBFSNode(8, ref tree, tree);
            InsertBFSNode(15, ref tree, tree);
            InsertBFSNode(22, ref tree, tree);
            InsertBFSNode(6, ref tree, tree);
            InsertBFSNode(4, ref tree, tree);
            InsertBFSNode(9, ref tree, tree);
            InsertBFSNode(2, ref tree, tree);
            InsertBFSNode(1, ref tree, tree);

            BFSNode inputNode = tree.right.left;
            //BFSNode node = GetInOrderSuccessorWithParentNode(inputNode);
            //MessageBox.Show(node.data.ToString());
            BFSNode node = GetInOrderSuccessorWithoutParentNode(inputNode, tree);
            MessageBox.Show(node.data.ToString());

            //BFSNode tree1 = null;
            //InsertBFSNode(50, ref tree1, tree1);
            //InsertBFSNode(55, ref tree1, tree1);
            //InsertBFSNode(40, ref tree1, tree1);
            //InsertBFSNode(30, ref tree1, tree1);
            //InsertBFSNode(20, ref tree1, tree1);            
            //InsertBFSNode(10, ref tree1, tree1);
            //InsertBFSNode(8, ref tree1, tree1);
            //InsertBFSNode(5, ref tree1, tree1);
            //InsertBFSNode(4, ref tree1, tree1);

            //node = GetInOrderSuccessor(tree1);
            //if (node != null)
            //{
            //    MessageBox.Show(node.data.ToString());
            //}
        }

        private BFSNode GetInOrderSuccessorWithParentNode(BFSNode node)
        {
            BFSNode p = null;
            if (node != null)
            {                
                if (node.right != null)
                {
                    p = LeftMostChild(node.right);
                }
                else
                {
                    //right side traversal
                    p = node.parent;
                    while (p != null && p.right == node)
                    {
                        node = p;
                        p = p.parent;
                    }

                    //left side traversal
                    while ((p = node.parent) != null)
                    {
                        if (node == p.left)
                        {
                            break;
                        }
                        node = p;
                    }
                }
            }
            return p;
        }


        private BFSNode GetInOrderSuccessorWithoutParentNode(BFSNode node, BFSNode root)
        {
            BFSNode p = null;            
            if (node != null)
            {
                if (node.right != null)
                {
                    p = LeftMostChild(node.right);
                }
                else
                {
                    BFSNode succ = null;
                    while (root!=null)
                    {                        
                        if (node.data < root.data)
                        {
                            succ = root;
                            root = root.left;
                        }
                        else if(node.data > root.data)
                        {
                            if (succ == null)
                            {
                                succ = root;
                            }
                            root = root.right;
                          
                        }
                        else
                        {
                            p=succ;
                            break; 
                        }
                    }                    
                }
            }
            return p;
        }
        private BFSNode LeftMostChild(BFSNode node)
        {
            if (node == null)
                return null;

            while(node.left!=null)
            {
                node = node.left;
            }
            return node;

         
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(6, ref tree);
            Insert(9, ref tree);
            Insert(1, ref tree);



            //Node node = CommonAncestor(tree, tree.left.left.left, tree.left.right);
            Node node = CommonAncestorSimple(tree, tree.left.left.left, tree.right.left);
            MessageBox.Show(node.data.ToString());

        }


        private Node CommonAncestorSimple(Node root, Node p, Node q)
        {
            Node parent = root;
            while (parent != null)
            {
                if (parent.data > p.data && parent.data >q.data)
                {
                    parent = parent.left;
                }
                else if (parent.data < p.data && parent.data < q.data)
                {
                    parent = parent.right;
                }
                else
                {
                    break;
                }

            }
            return parent;
        }

        private Node CommonAncestor(Node root, Node p, Node q)
        {
            if(q==p && (root.left ==q || root.right == q) )
            {
                return root;
            }

            int nodesFromLeft = covers(root.left,p,q);
            if (nodesFromLeft == TWO_NODES_FOUND || p==q)
            {
                if (root.left == p || root.left == q)
                    return root.left;
                else
                    return CommonAncestor(root.left, p, q);
            }
            else if (nodesFromLeft == ONE_NODES_FOUND)
            {
                if (root == p)
                    return p;
                else if (root == q)
                    return q;                
            }

            int nodesFromRight = covers(root.right, p, q);
            if (nodesFromRight == TWO_NODES_FOUND || p == q)
            {
                if (root.right == p || root.right == q)
                    return root.right;
                else
                    return CommonAncestor(root.right, p, q);
            }
            else if (nodesFromRight == ONE_NODES_FOUND)
            {
                if (root == p)
                    return p;
                else if (root == q) return q;
            }

            if (nodesFromLeft == ONE_NODES_FOUND && nodesFromRight == ONE_NODES_FOUND)
                return root;
            else
                return null;
            
        }

        private int covers(Node root, Node p, Node q)
        {
            int ret = NO_NODES_FOUND;
            if (root == null) return ret;
            if (root == p || root == q)
            {
                ret += 1;
            }
            ret += covers(root.left, p, q);
            if (ret == TWO_NODES_FOUND)
                return ret;
            return ret + covers(root.right, p, q);
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            treeToList(tree);
            printTree(tree);
            
        }


        private  Node treeToList(Node root)
        {
            // base case: empty tree -> empty list
            if (root == null) return (null);

            // Recursively do the subtrees (leap of faith!)
            Node aList = treeToList(root.left);
            Node bList = treeToList(root.right);

            // Make the single root node into a list length-1
            // in preparation for the appending
            //root.left = root;
            //root.right = root;

            // At this point we have three lists, and it's
            // just a matter of appending them together
            // in the right order (aList, root, bList)
            aList = append(aList, root);
            aList = append(aList, bList);

            return (aList);
        }

        private Node append(Node a, Node b)
        {
            // if either is null, return the other
            if (a == null) return (b);
            if (b == null) return (a);

            // find the last node in each using the .previous pointer
            Node aLast = a.left;
            Node bLast = b.right;

            // join the two together to make it connected and circular
            join(aLast, b);
            join(bLast, a);

            return (a);
        }

        private void join(Node a, Node b)
        {
            if (a!=null)
            { 
                a.right = b;
            }
            if (b!=null)
            { 
                b.left = a;
            }
        }


        private void printTree(Node root)
        {
            if (root==null) return;
            printTree(root.left);
            datas.Append(root.data.ToString() + ",");
            printTree(root.right);
        }

        private void LinkedListForm_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 4);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 0);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);            
            LLNodeFirst = InsertLinkList(LLNodeFirst, 2);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");
            

            LinkList node = null;

            while (LLNodeFirst != null)
            {
                LinkList temp = LLNodeFirst.next;
                LLNodeFirst.next = node;
                node = LLNodeFirst;
                LLNodeFirst = temp;
            }

            DisplayLinkList(node);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());


        }

        private void button14_Click(object sender, EventArgs e)
        {
            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            datas.Clear();
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(tree);
            while (q.Count > 0)
            {
                Node n = q.Dequeue();
                datas.Append(n.data + ",");
                if (n.left != null)
                    q.Enqueue(n.left);
                if (n.right != null)
                    q.Enqueue(n.right);
            }

            MessageBox.Show(datas.ToString());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }
    

        private void button17_Click(object sender, EventArgs e)
        {

            //Time complexity is O(n^2) since finding min from Linklist has to be travesal once and removing is another traversal

            LinkList linkList = null;           
            linkList = InsertLinkList(linkList, 5);
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 10);
            linkList = InsertLinkList(linkList, 110);            
            linkList = InsertLinkList(linkList, 112);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 123);
            linkList = InsertLinkList(linkList, 24);
            linkList = InsertLinkList(linkList, 3);


            datas.Clear();
            DisplayLinkList(linkList);
            MessageBox.Show(datas.ToString());

            if (linkList == null)
                return;

            LinkList smallest = linkList;            
            LinkList runner = linkList;
            LinkList prev = linkList;
            //5->4->10>110->112->3->123->24->3
            while (runner != null)
            {
                if (runner.next != null && runner.next.data < smallest.data)
                {
                    smallest = runner.next;
                    prev = runner;
                }
                runner = runner.next;                             
           }           

           while (prev == smallest || linkList.data == smallest.data)
           {
                linkList = linkList.next;
                prev = linkList;
           }

            LinkList current = prev.next;
            
            while (current != null)
            {
                if (current.data == smallest.data)
                {
                    LinkList temp = current.next;
                    prev.next = temp;
                    current = current.next;
                }
                else
                {
                    prev = current;
                    current = current.next;
                }
            }

            datas.Append("\n\n");
            DisplayLinkList(linkList);
            MessageBox.Show(datas.ToString());


        }

     

        private void button19_Click(object sender, EventArgs e)
        {
            LinkList LLNodeFirst = null;
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 1 ,next =null });
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 3, next = null });
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 2, next = null });
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 4, next = null });
            LLNodeFirst = insertInOrder(LLNodeFirst, new LinkList() { data = 5, next = null });            
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());
        }

        public LinkList insertInOrder(LinkList head, LinkList insert)
        {
            if (head == null)
            {
                return head = insert;                

            }

            LinkList previous = head;
            LinkList current = head.next;

            if (current == null)
            {
                if (previous.data < insert.data)
                {
                    previous.next = insert;
                    insert.next = null;
                    return head;
                }
                else
                {
                    insert.next = previous;
                    return insert;
                }
            }

            while (current != null)
            {
                if (previous.data < insert.data && current.data >= insert.data)
                {
                    previous.next = insert;
                    insert.next = current;
                    return head;
                }
                current = current.next;
                previous = previous.next;
            }

            previous.next = insert;
            
            return head;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int nthElement = 3;

            LinkList linkList = null;
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 5);
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 0);
            linkList = InsertLinkList(linkList, 11);
            linkList = InsertLinkList(linkList, 2);
            DisplayLinkList(linkList);
            datas.Append("\n");

            if (linkList == null)
            {
                MessageBox.Show("Linked List is empty");
            }

            LinkList lead = linkList;
            LinkList chase = linkList;

            for (int i = 0; i <3; i++)
            {
                if (lead == null)
                {
                    MessageBox.Show("Invalid nth location");
                }
                lead = lead.next;                
            }

            while (lead!= null)
            {
                lead = lead.next;
                chase = chase.next;
            }

            MessageBox.Show("The nth element from the last of the linked list is " + chase.data.ToString());
        }

        private void button20_Click(object sender, EventArgs e)
        {
             LinkList linkList = null;
            LinkList cyclicLinkList = null;
            linkList = InsertLinkList(linkList, 4);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 5);
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 0);
            linkList = InsertLinkList(linkList, 11);
            linkList = InsertLinkList(linkList, 2);
            DisplayLinkList(linkList);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());

            cyclicLinkList = linkList;

            while (cyclicLinkList != null && cyclicLinkList.next!=null)
            {
                cyclicLinkList = cyclicLinkList.next;
            }

            cyclicLinkList.next = linkList;
            

            LinkList fast = linkList;
            LinkList slow = linkList;
            bool isCylic = false;
            //4->3->5->1->0->11->2
            while (fast != null && slow != null && fast.next != null && !isCylic)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    isCylic = true;                    
                }
            }

            if (isCylic)
            {
                MessageBox.Show("LinkList is cyclic");
            }
            else
            {
                MessageBox.Show("LinkList is not cyclic");
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            int a, b, x, y;

            a = 1; b = 2; x = 3; y = 4;            
            while(a!=x && b!=y)
            {
                if (a > x)
                {
                    a++;
                }
                else
                {
                    a--;
                }
                if (b>y)
                {
                    b++;
                }
                else
                {
                    b--;
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //Time Complexity is O(n) where n is the number nodes
            LinkListCharacter string1 = null;
            string1 = InsertLinkListForCharacter(string1, 'g');
            string1 = InsertLinkListForCharacter(string1, 'e');
            string1 = InsertLinkListForCharacter(string1, 'e');
            string1 = InsertLinkListForCharacter(string1, 'k');
            string1 = InsertLinkListForCharacter(string1, 's');            

            LinkListCharacter string2 = null;
            string2 = InsertLinkListForCharacter(string2, 'g');
            string2 = InsertLinkListForCharacter(string2, 'e');
            string2 = InsertLinkListForCharacter(string2, 'e');
            string2 = InsertLinkListForCharacter(string2, 'k');
            string2 = InsertLinkListForCharacter(string2, 's');
            string2 = InsertLinkListForCharacter(string2, '1');

            int match = StringCompareForLinkList(string1, string2);
            if (match == -1)
            {
                MessageBox.Show("No match");
            }
            else if (match == 1)
            {
                MessageBox.Show("Partial match");
            }
            else if (match == 0)
            {
                MessageBox.Show("Match");
            }

        }

        private int StringCompareForLinkList(LinkListCharacter a, LinkListCharacter b)
        {
            int returnValue = 0;

            if (a == null || b == null)
            {
                return -1;
            }

            while (a!=null && b!=null && a.data == b.data)
            {
                a = a.next;
                b = b.next;
            }

            if (a != null && b != null)
                return a.data >= b.data ? 1 : -1;

            if (a != null && b == null)
                return 1;

            if (a == null && b != null)
                return -1;



            return returnValue;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //Refer : http://www.geeksforgeeks.org/rearrange-a-given-linked-list-in-place/
            //Time complexity : O(n)
            LinkList linkList = null;            
            linkList = InsertLinkList(linkList, 1);
            linkList = InsertLinkList(linkList, 2);
            linkList = InsertLinkList(linkList, 3);
            linkList = InsertLinkList(linkList, 4); 
            linkList = InsertLinkList(linkList, 5);
            DisplayLinkList(linkList);
            datas.Append("\n");
            
            Rearrage(linkList);
            DisplayLinkList(linkList);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());
        }

        private LinkList Rearrage(LinkList node)
        {
            //1->2->3->4->5

            LinkList slow = node;
            LinkList fast = slow.next;            

            while (fast!=null && fast.next!=null)
            {
                slow = slow.next;
                fast = fast.next.next;                    
            }

            LinkList head1 = node;
            LinkList head2 = slow.next;
            slow.next = null;

            //Reversing a link likst
            LinkList reverse = null;
            while(head2!=null)
            {
                LinkList temp = head2.next;
                head2.next = reverse;
                reverse = head2;
                head2 = temp;
            }

            head2 = reverse;
            node = new LinkList();
            LinkList curr = node;

            while (head1!=null || head2!=null)
            {
                if (head1!=null)
                {
                    curr.next = head1;
                    curr = curr.next;
                    head1 = head1.next;
                }

                if (head2 != null)
                {
                    curr.next = head2;
                    curr = curr.next;
                    head2 = head2.next;
                }
            }


            return node.next;

        }

        private void button23_Click(object sender, EventArgs e)
        {
            //Refer : http://www.geeksforgeeks.org/how-to-sort-a-linked-list-that-is-sorted-alternating-ascending-and-descending-orders/
            linkListNode = InsertLinkList(linkListNode, 10);
            linkListNode = InsertLinkList(linkListNode, 40);
            linkListNode = InsertLinkList(linkListNode, 53);
            linkListNode = InsertLinkList(linkListNode, 30);
            linkListNode = InsertLinkList(linkListNode, 67);
            linkListNode = InsertLinkList(linkListNode, 12);
            linkListNode = InsertLinkList(linkListNode, 89);
            DisplayLinkList(linkListNode);
            datas.Append("\n");            
            sort();
            DisplayLinkList(linkListNode);
            datas.Append("\n");
            MessageBox.Show(datas.ToString());

        }

        private void sort()
        {
            LinkList headA = new LinkList();
            LinkList headB = new LinkList();

            //Split the link list
            split(headA, headB);           

            headB = Reverse(headB);
            linkListNode =  MergeLinkList(headA, headB);
        }


        private void split(LinkList headA, LinkList headB)
        {

            LinkList asc = headA;
            LinkList desc = headB;
            LinkList current = linkListNode;
            
            while (current != null)
            {
                asc.next = current;
                asc = asc.next;
                current = current.next;

                if (current != null)
                {
                    desc.next = current;
                    desc = desc.next;
                    current = current.next;
                }
            }
            asc.next = null;
            desc.next = null;

            headA = headA.next;
            headB= headB.next;

        }

        private LinkList MergeLinkList(LinkList headA, LinkList headB)
        {
            LinkList mergedSortList = null;
            if (headA == null)
            {
                return headB;
            }
                
            if (headB == null)
            {
                return headA;
            }

            if (headA.data < headB.data)
            {
                mergedSortList = headA;
                mergedSortList.next = MergeLinkList(headA.next, headB);
            }
            else
            {
                mergedSortList = headB;
                mergedSortList.next = MergeLinkList(headA, headB.next);
            }

            return mergedSortList;
        }

        private LinkList Reverse(LinkList headB)
        {
            LinkList node = null;
            while (headB!= null)
            { 
                LinkList temp = headB.next;
                headB.next = node;
                node = headB;
                headB = temp;                
            }
            return node;
        }


      

        private void button24_Click(object sender, EventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            
            if (regexItem.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Valid");
            }
            else
            {
                MessageBox.Show("InValid");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //Time Complexity is O(n)
            LinkList list = null;
            list = InsertLinkList(list, 5);
            list = InsertLinkList(list, 1);
            list = InsertLinkList(list, 2);
            list = InsertLinkList(list, 3);
            list = InsertLinkList(list, 4);
            list = InsertLinkList(list, 5);
            list = InsertLinkList(list, 3);

            LinkList  current, previous;            
            current = list;
            previous = current;

            int input = 4;
                       
            while (current != null)
            {
                if (list == current && current.data >= input)
                {                    
                    list = current.next;
                }
                else if (current.data >= input)
                {
                    previous.next = current.next;                    
                }
                else
                {
                    previous = current;                    
                }
                current = current.next;

            }
            DisplayLinkList(list);
            MessageBox.Show(datas.ToString());



        




        }

        private void button26_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/merge-two-sorted-linked-lists-such-that-merged-list-is-in-reverse-order/
            //Time Complexity =  O(n+m) where n and m are the nodes in LinkList1 and LinkList2
            //Space Complexity = O(1) since traversing element has to stored one at a time 
            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 7);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 9);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");

            LinkList LLNodeSecond = null;
            LLNodeSecond = InsertLinkList(LLNodeSecond, 1);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 2);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 4);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 6);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 8);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 10);
            LLNodeSecond = InsertLinkList(LLNodeSecond, 12);

            DisplayLinkList(LLNodeSecond);
            datas.Append("\n");

            DisplayLinkList(MergeTwoSortedLinkListInReverseOrder(LLNodeFirst, LLNodeSecond));
            datas.Append("\n");

            MessageBox.Show(datas.ToString());
        }

        private LinkList MergeTwoSortedLinkListInReverseOrder(LinkList first, LinkList second)
        {
            //1->3->5->7->9->11
            //1->2->4->6->8->10->12
            LinkList list1 = first;
            LinkList list2 = second;

            LinkList result = null;
            LinkList temp = null;
            while (list1 != null && list2 != null)
            {
                if (list1.data == list2.data)
                {
                    temp = list1.next;
                    list1.next = result;
                    result = list1;
                    list1 = temp;
                    list2 = list2.next;
                }
                else if (list1.data < list2.data)
                {
                    temp = list1.next;
                    list1.next = result;
                    result = list1;
                    list1 = temp;
                }
                else if (list1.data > list2.data)
                {
                    temp = list2.next;
                    list2.next = result;
                    result = list2;
                    list2 = temp;
                }
                temp = null;
            }
            temp = null;
            while (list1!=null)
            {
                temp = list1.next;
                list1.next = result;
                result = list1;
                list1 = temp;
            }
            temp = null;
            while (list2!=null)
            {
                temp = list2.next;
                list2.next = result;
                result = list2;
                list2 = temp;
            }            

            return result;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //http://www.geeksforgeeks.org/select-a-random-node-from-a-singly-linked-list/
            //Time Complexity : O(n) where n is the number of nodes in the linked list

            datas.Clear();
            LinkList LLNodeFirst = null;
            LLNodeFirst = InsertLinkList(LLNodeFirst, 1);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 3);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 5);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 7);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 9);
            LLNodeFirst = InsertLinkList(LLNodeFirst, 11);
            DisplayLinkList(LLNodeFirst);
            datas.Append("\n");
            DisplayLinkList(this.GetRandomListNode(LLNodeFirst));            

            MessageBox.Show(datas.ToString());
        }

        private LinkList GetRandomListNode(LinkList linkList)
        {
            LinkList list = linkList;
            LinkList dummy = null;
            LinkList result = linkList;
            
            Random r = new Random();
            for (int n=2; list!= null; n++)
            {
                if (r.Next() % n == 0)
                {
                    LinkList temp = list.next;
                    list.next = dummy;
                    result = list;
                    list = temp;                    
                }
                else
                {
                    list = list.next;
                }
            }
             
            return result;
        }

        public static IEnumerable GetData(List<int> data)
        {            
            foreach(var d in data)
            {
                if (d>50)
                yield return d;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            int[] test = new int[] { 1, 2 };
            LinkList list = null;
            list = InsertLinkList(list, 5);
            list = InsertLinkList(list, 1);
            list = InsertLinkList(list, 2);
            list = InsertLinkList(list, 3);
            list = InsertLinkList(list, 4);
            list = InsertLinkList(list, 5);
            list = InsertLinkList(list, 3);

            LinkList current, previous;
            current = list;
            previous = current;


            while (current != null)
            {
                if (list == current && test.Contains(current.data))
                {
                    list = current.next;
                }
                else if (test.Contains(current.data))
                {
                    previous.next = current.next;
                }
                else
                {
                    previous = current;
                }
                current = current.next;

            }
            DisplayLinkList(list);
            MessageBox.Show(datas.ToString());




        }

        private void button29_Click(object sender, EventArgs e)
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            datas.Clear();
            Node tree = this.CreateBST(data, 0, data.Length-1);                                                
            MessageBox.Show(datas.ToString());
        }


        private Node CreateBST(int[] data, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            int mid = (start + end) / 2;
            datas.Append(data[mid].ToString() + ",") ;
            Node node = new Node();
            node.data = data[mid];
            node.left = CreateBST(data, start, mid-1);
            node.right = CreateBST(data, mid + 1, end);
            return node;
        }



        private void button30_Click(object sender, EventArgs e)
        {
            //Func<int, int> f = X(Sum);
            //var res = f(5);
            //MessageBox.Show(res.ToString());


            //string[] input = {"5", "-2","4", "Z","X", "9", "+", "+" };
            //int sum = totalScore(input, 8);
            //MessageBox.Show(sum.ToString());
            //int red = 255;
            //int blue = 23;
            //int green = 0;
            //MessageBox.Show(string.Format("Cloning color RGB: {0,3},{1,3},{2,3}", red, blue, green));

          





        }


        public static int totalScore(string[] blocks, int n)
        {
            if (blocks == null || n == 0)
            {
                return 0;
            }

            int sum = 0;
            int[] scores = new int[blocks.Length];
            string blockValue = string.Empty;
            int currentScoreIndex = 0;
            for (int i = 0; i < blocks.Length; i++)
            {
                //At any given time the symbols in the blocks list should contain one character 
                    blockValue = blocks[i];
                    if (blockValue == "X")
                    {
                        if (i - 1 >= 0)
                        {
                            scores[currentScoreIndex] = ConvertToInt(blocks[currentScoreIndex - 1]) * 2;
                            currentScoreIndex++;
                        }
                    }
                    else if (blockValue == "+")
                    {
                        if (i - 1 >= 0)
                        {
                            if (i - 2 >= 0)
                            {
                                scores[currentScoreIndex] = scores[currentScoreIndex - 1] + scores[currentScoreIndex - 2];
                                currentScoreIndex++;
                            }
                            else
                            {
                                scores[currentScoreIndex] = scores[currentScoreIndex - 1];
                                currentScoreIndex++;
                        }
                        }
                    }
                    else if (blockValue == "Z")
                    {
                        if (i - 1 >= 0)
                        {
                            scores[currentScoreIndex - 1] = 0;
                            currentScoreIndex--;
                        }
                    }
                    else
                    {
                        scores[currentScoreIndex] = ConvertToInt(blocks[i]);
                        currentScoreIndex++;
                }
                
            }

            for (int i = 0; i < scores.Length; i++)
            {
                sum = sum + scores[i];
            }
            return sum;
        }

        private static int ConvertToInt(string blockValue)
        {
            int returnValue = 0;
            int.TryParse(blockValue, out returnValue);
            return returnValue;
        }

        class Tst
        {
            public int t = 0;
        }

        static Func<int, int> X(Func<int, int, int> f)
        {
            Console.WriteLine(f.Method.Name);
            return a => f(a, 4);
        }

      

        static int Sum(int x, int y)
        {
            return x + y;
        }


        private string CheckString(string line)
        {
            string returnString = "YES";
            if (string.IsNullOrEmpty(line))
            {
                return returnString;
            }

            bool startingParam = false;
            foreach(char c in line)
            {
                if (!((c >= 97 && c <= 122) || c == 32 || c == 58))
                {
                    returnString = "NO";
                    break;
                }
                else if (c == 40 && !startingParam)
                {
                    startingParam = true;
                }
                else if (c == 41 && startingParam)
                {
                    startingParam = false;
                }
                else
                {
                    returnString = "NO";
                    break;
                }
            }

            return returnString;
        }

        private void Check_if_given_sorted_sub_sequence_exists_in_binary_search_tree_Click(object sender, EventArgs e)
        {
            // http://www.geeksforgeeks.org/check-if-given-sorted-sub-sequence-exists-in-binary-search-tree/
            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(6, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(9, ref tree);
            datas.Clear();            
            InOrder(tree);

            int[] seq = new int[] {4, 5, 6 };

            MessageBox.Show(isSequenceExists(tree, seq) ? string.Format("Sequence: {0} exists in tree :{1}", string.Join(",", seq), datas.ToString()) : string.Format("Sequence: {0} does not exists in tree: {1}", string.Join(",", seq), datas.ToString()));

        }

        private bool isSequenceExists(Node tree, int[] seq)
        {

            int sequenceAvail = 0;

            this.GetInOrderNode(tree, seq, ref sequenceAvail);
            return (sequenceAvail == seq.Count());


        }

        private void GetInOrderNode (Node tree, int[] seq, ref int sequenceAvailIndex)
        {

            if (tree == null )
            {
                return;
            }

            GetInOrderNode(tree.left, seq, ref sequenceAvailIndex);

            if (sequenceAvailIndex >= seq.Count())
                return;

            if (tree.data == seq[sequenceAvailIndex])
                sequenceAvailIndex++;

            GetInOrderNode(tree.right, seq, ref sequenceAvailIndex);
        }

        private void Check_whether_BST_contains_Dead_End_or_not_Click(object sender, EventArgs e)
        {
            // http://www.geeksforgeeks.org/check-whether-bst-contains-dead-end-not/
            //Time Complexity is O(n)
            Node tree = null;
            //Insert(10, ref tree);
            //Insert(5, ref tree);
            //Insert(20, ref tree);
            //Insert(3, ref tree);
            //Insert(8, ref tree);
            //Insert(6, ref tree);
            //Insert(15, ref tree);
            //Insert(22, ref tree);
            //Insert(1, ref tree);
            //Insert(2, ref tree);
            //Insert(4, ref tree);
            //Insert(9, ref tree);
            Insert(8, ref tree);
            Insert(7, ref tree);
            Insert(10, ref tree);
            Insert(2, ref tree);            
            Insert(9, ref tree);
            Insert(13, ref tree);
            //Insert(4, ref tree);
            datas.Clear();
            datas.Append("\r\n InOrder Traversal :");
            InOrder(tree);
            MessageBox.Show(datas.ToString());

            Node root = tree;
            List<int> treeNodes = new List<int>();
            List<int> leafNodes = new List<int>();
            
            treeNodes.Add(0);
            this.TraverseAndInsertIntoHashSet(root, treeNodes, leafNodes);

            int leafNodeCount = leafNodes.Count;
            bool isDeadEnd = false;
            for (int i = 0; i< leafNodeCount ; i++)
            {
                if (

                        //treeNodes.Find(x=>x == leafNodes[i]+1) != treeNodes.Last() &&
                        //treeNodes.Find(x => x == leafNodes[i]-1) != treeNodes.Last()   
                        treeNodes.Where(w=>w==leafNodes[i]+1 || w==leafNodes[i]-1).Count() > 0 
                   )
                {
                    isDeadEnd = true;
                    break;
                }
            }

            MessageBox.Show(isDeadEnd? "Tree is dead end" : "Tree is not dead end" );



        }


        private void TraverseAndInsertIntoHashSet(Node root, List<int> treeNodes, List<int> leafNodes )
        {
            if (root == null)
            {
                return;
            }
            treeNodes.Add(root.data);

            if (root.left == null && root.right == null)
            {
                leafNodes.Add(root.data);
                return;
            }

            TraverseAndInsertIntoHashSet(root.left, treeNodes, leafNodes);
            TraverseAndInsertIntoHashSet(root.right, treeNodes, leafNodes);
        }

        private void ConnectNodes_Click(object sender, EventArgs e)
        {
            NodeWithNext tree = null;
            InsertNodeWithNext(10, ref tree);
            InsertNodeWithNext(5, ref tree);
            InsertNodeWithNext(20, ref tree);
            InsertNodeWithNext(3, ref tree);
            InsertNodeWithNext(8, ref tree);
            InsertNodeWithNext(6, ref tree);
            InsertNodeWithNext(15, ref tree);
            InsertNodeWithNext(22, ref tree);
            InsertNodeWithNext(1, ref tree);
            InsertNodeWithNext(2, ref tree);
            InsertNodeWithNext(4, ref tree);
            InsertNodeWithNext(9, ref tree);
            datas.Clear();
            InOrderWithNext(tree);            
            MessageBox.Show(datas.ToString());

            Queue<NodeWithNext> q = new Queue<NodeWithNext>();
            if (tree.left != null)
            {
                q.Enqueue(tree.left);
            }

            if (tree.right != null)
            {
                q.Enqueue(tree.right);
            }

            while (true)
            {
                List<NodeWithNext> nextNodes = new List<NodeWithNext>();
                while (q.Count > 0)
                {
                    nextNodes.Add(q.Dequeue());                    
                }

                NodeWithNext previous = null;
                NodeWithNext current = null;
                foreach(var n in nextNodes )
                {
                    if (current == null)
                    {
                        current = n;
                    }
                    else
                    {
                        previous = current;
                        current = n;
                        previous.next = current;                        
                        if (previous.left != null)
                        {
                            q.Enqueue(previous.left);
                        }

                        if (previous.right != null)
                        {
                            q.Enqueue(previous.right);
                        }
                    }
                }
                if (current.left != null)
                {
                    q.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    q.Enqueue(current.right);
                }

                if (q.Count == 0)
                {
                    break;
                }
            }


        }

        private void InOrderWithNext(NodeWithNext node)
        {
            if (node==null)
            {
                return;
            }
            InOrderWithNext(node.left);
            datas.Append(node.data.ToString() + ",");
            InOrderWithNext(node.right);
        }

        private void btnDistance_of_two_nodes_in_Binary_Search_Tree_Click(object sender, EventArgs e)
        {
            /*
                                          10
                                       /      \
                                      /        \
                                     /          \
                                    /            \                           
                                   /              \
                                  5               20
                                /  \             / \
                               /    \           /   \  
                              /      \         /     \
                             3        8       15     22 
                            / \      / \ 
                           /   \    /   \
                          1    4    6    9
                           \
                            \
                             2
            */


            Node tree = null;
            Insert(10, ref tree);
            Insert(5, ref tree);
            Insert(20, ref tree);
            Insert(3, ref tree);
            Insert(8, ref tree);
            Insert(6, ref tree);
            Insert(15, ref tree);
            Insert(22, ref tree);
            Insert(1, ref tree);
            Insert(2, ref tree);
            Insert(4, ref tree);
            Insert(9, ref tree);
            datas.Clear();
            datas.Append("\r\n InOrder Traversal :");
            InOrder(tree);
            MessageBox.Show(datas.ToString());

            int input1 = 9;
            int input2 = 9;

            Node commonAccesstorNode = this.GetCommonAncestor_Distance_of_two_nodes_in_Binary_Search_Tree(tree, input1, input2);
            int distance1 = this.FindDistanceForElementInBinary_SearchTree(commonAccesstorNode, input1);
            int distance2 = -1;
            if (distance1 > 0)
            {
                distance2 = this.FindDistanceForElementInBinary_SearchTree(commonAccesstorNode, input2);
            }

            MessageBox.Show($"The distance between {input1} and {input2} is {(distance1 > 0 && distance2>0 ? (distance1 + distance2).ToString() : "-1" )}");



        }

        private int FindDistanceForElementInBinary_SearchTree(Node node, int input)
        {
            int distance = -1;
            bool nodeExists = false;
            if (node == null)
            {
                return distance;
            }

            distance = 0;
            while (node != null)
            {
                if (node.data > input)
                {
                    node = node.left;
                    distance++;
                }
                else if (node.data < input)
                {
                    node = node.right;
                    distance++;
                }
                else if (node.data == input)
                {
                    nodeExists = true;
                    break;
                }
            }
            
            return nodeExists ? distance : -1;
        }

        private Node GetCommonAncestor_Distance_of_two_nodes_in_Binary_Search_Tree(Node tree, int input1, int input2)
        {
            if (tree==null)
            {
                return null;
            }

            while (tree!=null)
            {
                if (tree.data > input1 && tree.data > input2)
                {
                    tree = tree.left;
                }
                else if (tree.data<input1 && tree.data < input2)
                {
                    tree = tree.right;
                }
                else
                {
                    break;
                }
            }

            return tree;
        }

        private void btnBinary_Tree_Is_BST_Click(object sender, EventArgs e)
        {
            /*                  Proper  BST
                                          10
                                       /      \
                                      /        \
                                     /          \
                                    /            \                           
                                   /              \
                                  5               20
                                /  \             / \
                               /    \           /   \  
                              /      \         /     \
                             3        8       15     22 
                            / \      / \ 
                           /   \    /   \
                          1    4    6    9
                           \
                            \
                             2
            

                                    Improper BST : In order travel output would be 22 20 15 10 9 8 6 5 4 3 2 1
                                          10
                                       /      \
                                      /        \
                                     /          \
                                    /            \                           
                                   /              \
                                  20              5
                                /  \              / \
                               /    \            /   \  
                              /      \          /     \
                             22      15        8       3                               
                                              / \      / \ 
                                             /   \    /   \
                                            9     6  4     1
                                                         / 
                                                        /
                                                       2  



            Time Complexity is O(h) where h is the height of the node
            Space Complexity is O(1)

            */

            Node tree = null;
            //Insert(10, ref tree);
            //Insert(5, ref tree);
            //Insert(20, ref tree);
            //Insert(3, ref tree);
            //Insert(8, ref tree);
            //Insert(6, ref tree);
            //Insert(15, ref tree);
            //Insert(22, ref tree);
            //Insert(1, ref tree);
            //Insert(2, ref tree);
            //Insert(4, ref tree);
            //Insert(9, ref tree);
            InsertTreeNodeImproperly(10, ref tree);
            InsertTreeNodeImproperly(5, ref tree);
            InsertTreeNodeImproperly(20, ref tree);
            InsertTreeNodeImproperly(3, ref tree);
            InsertTreeNodeImproperly(8, ref tree);
            InsertTreeNodeImproperly(6, ref tree);
            InsertTreeNodeImproperly(15, ref tree);
            InsertTreeNodeImproperly(22, ref tree);
            InsertTreeNodeImproperly(1, ref tree);
            InsertTreeNodeImproperly(2, ref tree);
            InsertTreeNodeImproperly(4, ref tree);
            InsertTreeNodeImproperly(9, ref tree);
            datas.Clear();            
            InOrder(tree);
            MessageBox.Show($"\r\n InOrder Traversal:{datas.ToString()}");
            MessageBox.Show($"Is valid BST {this.IsBSTUsingInOrderTravel(tree, null).ToString()}"  );



        }
        

        private bool IsBSTUsingInOrderTravel(Node current, Node prev)
        {
            
            if (current != null)
            {
                if (!IsBSTUsingInOrderTravel(current.left, prev))
                {
                    return false;
                }

                if (prev!=null && current.data <= prev.data)
                {
                    return false;
                }

                prev = current;
                return IsBSTUsingInOrderTravel(current.right, prev);
            }
            return true;            
        }

    }

    class Graph
    {
        public object data;
        public List<Graph> next;
    }

    class Node
    {
        public int data;
        public Node right;
        public Node left;       
    }

    class NodeWithNext
    {
        public int data;
        public NodeWithNext right;
        public NodeWithNext left;
        public NodeWithNext next;
    }

    public class BFSNode
    {
        public int data;
        public BFSNode right;
        public BFSNode left;
        public BFSNode parent;


    }

    public class LinkList
    {
        public int data;
        public LinkList next;
    }

    public class LinkListCharacter
    {
        public char data;
        public LinkListCharacter next;
    }

    public interface ITest
    {
        void Testing();
    }

    public abstract class AbstractTest : LinkListCharacter, ITest
    {
        public abstract void TestintAbstract();
        public void TestintAbstract1()
        {

        }

        public void Testing()
        { }
    }
        
  
}
