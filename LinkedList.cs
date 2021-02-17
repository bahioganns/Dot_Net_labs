internal class Node {
    internal Node prev;
    internal Node next;

    internal int data;

    public Node(int d) {
        next = null;
        prev = null;

        data = d;
    }
}

class LinkedList {
    internal Node head = null;
    internal Node tail = null;

    public override string ToString() {
        Node current = head;

        string res = "";
        while (current != null) {
            res += $"{current.data} -> ";

            current = current.next;
        }
        res += "null";

        return res;
    }

    public void push_back(int val) {
        if (head == null) {
            head = new Node(val);
            tail = head;
        } else {
            Node new_node = new Node(val);
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
}
