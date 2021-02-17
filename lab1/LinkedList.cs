using System;

internal class Node<T> {
    internal Node<T> prev;
    internal Node<T> next;

    internal T data;

    public Node(T d) {
        next = null;
        prev = null;

        data = d;
    }
}

public class LinkedList<T> {
    internal Node<T> head = null;
    internal Node<T> tail = null;

    public override string ToString() {
        Node<T> current = head;

        string res = "";
        while (current != null) {
            res += $"{current.data} -> ";

            current = current.next;
        }
        res += "null";

        return res;
    }

    public void push_back(T val) {
        if (head == null) {
            head = new Node<T>(val);
            tail = head;
        } else {
            Node<T> new_node = new Node<T>(val);
            new_node.prev = tail;

            tail.next = new_node;
            tail = new_node;
        }
    }

    public void pop_back() {
        if (tail != null && tail.prev != null) {
            tail = tail.prev;
            tail.next = null;
        } else {
            head = null;
            tail = null;
        }
    }

    public T back() {
        if (tail != null) {
            return tail.data;
        }

        throw new Exception("Nothing at list");
    }

    public void remove_by_value(T val) {
    }

    public void remove_by_index(T val) {
    }
}