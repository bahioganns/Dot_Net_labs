using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class BinaryTree
    {
        public TreeNode root;

        public bool Add(int value)
        {
            TreeNode before = null, after = this.root;

            while (after != null)
            {
                before = after;
                if (value < after.data) //Is new node in left tree? 
                    after = after.leftNode;
                else if (value > after.data) //Is new node in right tree?
                    after = after.rightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            TreeNode newNode = new TreeNode();
            newNode.data = value;

            if (this.root == null)//Tree ise empty
                this.root = newNode;
            else
            {
                if (value < before.data)
                    before.leftNode = newNode;
                else
                    before.rightNode = newNode;
            }

            return true;
        }

        public TreeNode Find(int value)
        {
            return this.Find(value, this.root);
        }

        private TreeNode Find(int value, TreeNode parent)
        {
            if (parent != null)
            {
                if (value == parent.data) return parent;
                if (value < parent.data)
                    return Find(value, parent.leftNode);
                else
                    return Find(value, parent.rightNode);
            }

            return null;
        }

        public void Remove(int value)
        {
            this.root = Remove(this.root, value);
        }

        private TreeNode Remove(TreeNode parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.data) parent.leftNode = Remove(parent.leftNode, key);
            else if (key > parent.data)
                parent.rightNode = Remove(parent.rightNode, key);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.leftNode == null)
                    return parent.rightNode;
                else if (parent.rightNode == null)
                    return parent.leftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.data = MinValue(parent.rightNode);

                // Delete the inorder successor  
                parent.rightNode = Remove(parent.rightNode, parent.data);
            }

            return parent;
        }

        private int MinValue(TreeNode node)
        {
            int minv = node.data;

            while (node.leftNode != null)
            {
                minv = node.leftNode.data;
                node = node.leftNode;
            }

            return minv;
        }
        public void TraversePreOrder(TreeNode parent)
        {
            if (parent != null)
            {
                Console.Write(parent.data + " ");
                TraversePreOrder(parent.leftNode);
                TraversePreOrder(parent.rightNode);
            }
        }
    }
}
