using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class DoubleLinkedList<T>
    {
        public Node<T> head;
        public Node<T> tail;


        public void Output()
        {
            Node<T> temp = head;

            if (temp == null)
            {
                System.Console.WriteLine("list is empty");
                return;
            }

            while (temp != null)
            {
                System.Console.WriteLine(temp.data);
                temp = temp.next;
            }
        }

        public void InsertLast(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                newNode.prev = null;
                head = newNode;
                return;
            }

            Node<T> lastNode = GetLastNode();
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }

        public Node<T> GetLastNode()
        {
            Node<T> temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        public void ReverseList()
        {
            DoubleLinkedList<T> res = new DoubleLinkedList<T>();

            Node<T> current = GetLastNode();

            while (current != null)
            {
                res.InsertLast(current.data);
                current = current.prev;
            }

            head = res.head;
            tail = res.tail;
        }

        public bool Contains(T key)
        {
            Node<T> temp = head;

            while (temp != null)
            {
                if (temp.data.Equals(key))
                {
                    return true;
                }

                temp = temp.next;
            }

            return false;
        }

        public void DeleteFirstByKey(T key)
        {
            Node<T> temp = head;


            if (temp != null && temp.data.Equals(key))
            {
                if (head.next != null)
                {
                    head = temp.next;
                    head.prev = null;
                    return;
                }
                head = null;
            }
            while (temp != null && !temp.data.Equals(key))
            {
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
            }
        }

        public void DeleteAllByKey(T key)
        {
            while (Contains(key))
            {

                DeleteFirstByKey(key);
            }
        }
    }
}
