﻿namespace WindowsFormsApplication3
{
    partial class DoubleLinkList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Find_pairs_with_given_sum_in_doubly_linked_list = new System.Windows.Forms.Button();
            this.Insert_node_in_sorted_order = new System.Windows.Forms.Button();
            this.Delete_node = new System.Windows.Forms.Button();
            this.btn_Convert_Binary_Tree_into_Double_Linked_List = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Find_pairs_with_given_sum_in_doubly_linked_list
            // 
            this.Find_pairs_with_given_sum_in_doubly_linked_list.Location = new System.Drawing.Point(16, 10);
            this.Find_pairs_with_given_sum_in_doubly_linked_list.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Find_pairs_with_given_sum_in_doubly_linked_list.Name = "Find_pairs_with_given_sum_in_doubly_linked_list";
            this.Find_pairs_with_given_sum_in_doubly_linked_list.Size = new System.Drawing.Size(368, 39);
            this.Find_pairs_with_given_sum_in_doubly_linked_list.TabIndex = 0;
            this.Find_pairs_with_given_sum_in_doubly_linked_list.Text = "Find pairs with given sum in doubly linked list";
            this.Find_pairs_with_given_sum_in_doubly_linked_list.UseVisualStyleBackColor = true;
            this.Find_pairs_with_given_sum_in_doubly_linked_list.Click += new System.EventHandler(this.Find_pairs_with_given_sum_in_doubly_linked_list_Click);
            // 
            // Insert_node_in_sorted_order
            // 
            this.Insert_node_in_sorted_order.Location = new System.Drawing.Point(16, 54);
            this.Insert_node_in_sorted_order.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Insert_node_in_sorted_order.Name = "Insert_node_in_sorted_order";
            this.Insert_node_in_sorted_order.Size = new System.Drawing.Size(368, 39);
            this.Insert_node_in_sorted_order.TabIndex = 1;
            this.Insert_node_in_sorted_order.Text = "Insert node in sorted order";
            this.Insert_node_in_sorted_order.UseVisualStyleBackColor = true;
            this.Insert_node_in_sorted_order.Click += new System.EventHandler(this.Insert_node_in_sorted_order_Click);
            // 
            // Delete_node
            // 
            this.Delete_node.Location = new System.Drawing.Point(16, 97);
            this.Delete_node.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Delete_node.Name = "Delete_node";
            this.Delete_node.Size = new System.Drawing.Size(368, 39);
            this.Delete_node.TabIndex = 2;
            this.Delete_node.Text = "Delete node ";
            this.Delete_node.UseVisualStyleBackColor = true;
            this.Delete_node.Click += new System.EventHandler(this.Delete_node_Click);
            // 
            // btn_Convert_Binary_Tree_into_Double_Linked_List
            // 
            this.btn_Convert_Binary_Tree_into_Double_Linked_List.Location = new System.Drawing.Point(16, 141);
            this.btn_Convert_Binary_Tree_into_Double_Linked_List.Name = "btn_Convert_Binary_Tree_into_Double_Linked_List";
            this.btn_Convert_Binary_Tree_into_Double_Linked_List.Size = new System.Drawing.Size(368, 36);
            this.btn_Convert_Binary_Tree_into_Double_Linked_List.TabIndex = 3;
            this.btn_Convert_Binary_Tree_into_Double_Linked_List.Text = "Convert Binary Tree into Double Linked List";
            this.btn_Convert_Binary_Tree_into_Double_Linked_List.UseVisualStyleBackColor = true;
            this.btn_Convert_Binary_Tree_into_Double_Linked_List.Click += new System.EventHandler(this.btn_Convert_Binary_Tree_into_Double_Linked_List_Click);
            // 
            // DoubleLinkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 686);
            this.Controls.Add(this.btn_Convert_Binary_Tree_into_Double_Linked_List);
            this.Controls.Add(this.Delete_node);
            this.Controls.Add(this.Insert_node_in_sorted_order);
            this.Controls.Add(this.Find_pairs_with_given_sum_in_doubly_linked_list);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DoubleLinkList";
            this.Text = "DoubleLinkList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Find_pairs_with_given_sum_in_doubly_linked_list;
        private System.Windows.Forms.Button Insert_node_in_sorted_order;
        private System.Windows.Forms.Button Delete_node;
        private System.Windows.Forms.Button btn_Convert_Binary_Tree_into_Double_Linked_List;
    }
}