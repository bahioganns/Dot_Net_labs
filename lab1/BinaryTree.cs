using System;

namespace BinaryTree
{
    public class Node<K, V>
    {
        public Node<K, V> left;
        public Node<K, V> right;
        public K key;
        public V val;

        public Node(K key, V val)
        {
            left = null;
            right = null;

            this.key = key;
            this.val = val;
        }
    }

    public class BinaryTree<K, V> where K: IComparable
    {
        public Node<K, V> root = null;

        public void insert(K key, V val)
        {
            insert(ref this.root, key, val);
        }

        private void insert(ref Node<K, V> root, K key, V val)
        {
            Node<K, V> new_node = new Node<K, V>(key, val);
            if (root == null)
            {
                root = new_node;
                return;
            }

            if (key.CompareTo(root.key) > 0)
            {
                insert(ref root.right, key, val);
            }
            else if (key.CompareTo(root.key) < 0)
            {
                insert(ref root.left, key, val);
            }
            else
            {
                root.val = val;
            }
        }

        public Node<K, V> find(K key)
        {
            return find(this.root, key);
        }

        private Node<K, V> find(Node<K, V> root, K key)
        {
            if (root == null)
            {
                return null;
            }

            if (key.CompareTo(root.key) > 0)
            {
                return find(root.right, key);
            }
            else if (key.CompareTo(root.key) < 0)
            {
                return find(root.left, key);
            }

            return root;
        }

        public void remove(K key)
        {
            this.root = remove(ref this.root, key);
        }

        private Node<K, V> remove(ref Node<K, V> root, K key)
        {
            if (root == null)
            {
                return root;
            }

            if (key.CompareTo(root.key) > 0)
            {
                return remove(ref root.right, key);
            }
            else if (key.CompareTo(root.key) < 0)
            {
                return remove(ref root.left, key);
            }

            if (root.left == null && root.right == null)
            {
                root = null;
            }
            else if (root.left == null)
            {
                root = root.right;
            }
            else if (root.right == null)
            {
                root = root.left;
            }
            else
            {
                root.key = min_key(root.right);
                root.right = remove(ref root.right, root.key);
            }

            return root;
        }

        private K min_key(Node<K, V> root)
        {
            K res = root.key;

            while (root.left != null)
            {
                res = root.left.key;
                root = root.left;
            }

            return res;
        }
    }
}
