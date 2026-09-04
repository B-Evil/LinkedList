using System;
using System.Collections;
using System.Dynamic;

namespace DataStructures.LinkedList;
public class LinkedListApp {
    public static void Main(string[] args){
        LinkedList list = new LinkedList();
        list.AddAtTail("1.0 BTC");
        list.AddAtTail("2.5 BTC");
        list.AddAt("0.4 BTC", 1);
        list.AddAt("5.4 BTC", 2);
        list.AddAt("1.3 BTC", 3);
        list.AddAt("7.4 BTC", 3);
        Console.WriteLine(list.Get(4));
    }
}

public class Node {
    public string Data { get; set; }
    public Node? Next { get; set; }

    public Node (string Data) {
        this.Data = Data;
        Next = null; 
    }

    public override string ToString() {
        return $"Node - [Data: {Data}]";
    }
}

public class LinkedList: IEnumerable{
    public Node? Head { get; private set; }
    public Node? Tail { get; private set; }
    public int Count { get; private set; }

    public LinkedList () {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public void AddAtHead (string data) {
        Node newNode = new Node(data);
        Count++; 

        if(Head == null) {
            Head = newNode;
            Tail = newNode;
        }else {
            newNode.Next = Head;
            Head = newNode;
        }
    }

    public void AddAtTail (string data) {
        if(Count == 0) {
            AddAtHead(data);
        }else {
            Node newNode = new Node(data);
            Count++;
            Tail.Next = newNode; 
            Tail = newNode;
        }
    }

    public void AddAt (string data, int index) {
        if(index < 0 || index > Count ) { 
            string msg = $"Invalid index - [{index}]. Valid ranger: 0 to {Count - 1}";
            throw new IndexOutOfRangeException(msg);
        }

        if(index == 0) {
            AddAtHead(data);
        }else if(index == Count) {
            AddAtTail(data);
        } else {
            Node newNode = new (data); 
            Node? runner = Head; 
            Node follower = null;
            for(int i = 0; i < index; i++) {
                follower = runner; 
                runner = runner.Next;
            }
            Count++;
            follower.Next = newNode;
            newNode.Next = runner;
        }
    }

    public Node Get (int index) {
        if (index < 0 || index >= Count) {
            string msg = $"Invalid index - [{index}]. Valid ranger: 0 to {Count - 1}";
            throw new IndexOutOfRangeException(msg);
        }

        if (index == 0) {
            return Head;
        }else if (index == Count - 1) {
            return Tail;
        }else {
            Node? current = Head; 
            for(int i = 0; i < index; i++) {
                current = current.Next; 
            }
            return current;
        }
    }

    public void DeleteAtHead() {
        if(Count == 0) {
            string msg = $"Invalid index. Valid ranger: 0 to {Count - 1}";
            throw new IndexOutOfRangeException(msg);
        }

        Head = Head.Next; 
        Count--; 

        if(Count == 0) {
            Tail = null;
        }
    }

    public void DeleteAtTail() {
        if(Count == 0) {
            string msg = $"Invalid index. Valid Ranger: 0 to {Count - 1}";
            throw new IndexOutOfRangeException(msg);
        }

        if(Count == 1) {
           DeleteAtHead(); 
        } else {
            var secondLast = Get(Count - 2);
            Tail = secondLast; 
            Tail.Next = null;
            Count--;
        }
    }

    public void DeleteAt(int index) {
        if(index < 0 || index > Count || Count == 0) {
            string msg = $"Invalid index. valid Ranger: 0 to {Count - 1}";
            throw new IndexOutOfRangeException(msg);
        }

        if(index == 1){
            DeleteAtHead();
        }else if(index == Count - 1) {
            DeleteAtTail();
        }
        else {
            var previous = Get(index - 1); 
            previous.Next = previous.Next.Next;
            Count--;
        }
    }




    public IEnumerator GetEnumerator () {
        Node? current = Head;
        while(current != null) {
            yield return current;
            current = current.Next;
        }
    }
} 