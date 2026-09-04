using DataStructures.LinkedList;
namespace LinkedListTest01;

[TestFixture]
public class LinkedListTest {
    [Test]
    public void AddAtHead () {
        LinkedList list = new ();
        list.AddAtHead("D");
        Assert.That(list.Head.Data, Is.EqualTo("D"));
        list.AddAtHead("C");
        Assert.That(list.Head.Data, Is.EqualTo("C"));
        list.AddAtHead("B");
        Assert.That(list.Head.Data, Is.EqualTo("B"));
        list.AddAtHead("A");
        Assert.That(list.Head.Data, Is.EqualTo("A"));

    }

    [Test]
    public void AddAtTail () {
        LinkedList list = new (); 
        list.AddAtTail("A");
        Assert.That(list.Tail.Data, Is.EqualTo("A"));
        list.AddAtTail("B");
        Assert.That(list.Tail.Data, Is.EqualTo("B"));
        list.AddAtTail("C");
        Assert.That(list.Tail.Data, Is.EqualTo("C"));
        list.AddAtTail("D");
        Assert.That(list.Tail.Data, Is.EqualTo("D"));
    }

    [Test]
    public void GetOutOfRangeException () {
        LinkedList list = new ();
        list.AddAtTail("A");
        list.AddAtTail("B");
        list.AddAtTail("C");
        list.AddAtTail("D");
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(-5));
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(10));
        Assert.Throws<IndexOutOfRangeException>(() => list.Get(4));
    }

    [Test]
    public void GetAtHead () {
        LinkedList list = new (); 
        list.AddAtTail("A");
        list.AddAtTail("B");
        list.AddAtTail("C");
        list.AddAtTail("D");
        Assert.That(list.Get(0).Data, Is.EqualTo("A"));
        list.AddAtHead("E");
        Assert.That(list.Get(0).Data, Is.EqualTo("E"));
    }

    [Test]
    public void GetAtTail () {
        LinkedList list = new (); 
        list.AddAtTail("A");
        list.AddAtTail("B");
        list.AddAtTail("C");
        list.AddAtTail("D");
        Assert.That(list.Get(3).Data, Is.EqualTo("D"));
        list.AddAtTail("E"); 
        Assert.That(list.Get(4).Data, Is.EqualTo("E"));
    }

    [Test]
    public void GetAtIndex () {
        LinkedList list = new (); 
        list.AddAtTail("A");
        list.AddAtTail("B");
        list.AddAtTail("C");
        list.AddAtTail("D");
        list.AddAtTail("E");
        list.AddAtTail("F");
        Assert.That(list.Get(3).Data, Is.EqualTo("D"));
        Assert.That(list.Get(5).Data, Is.EqualTo("F"));
        Assert.That(list.Get(1).Data, Is.EqualTo("B"));
    }

    [Test]
    public void AddAtExceptionOutRange (){
        LinkedList list = new ();
        list.AddAtTail("A");
        list.AddAtTail("D");
        list.AddAtTail("H");
        Assert.Throws<IndexOutOfRangeException>(() => list.AddAt("B", -4));
        Assert.Throws<IndexOutOfRangeException>(() => list.AddAt("C", 10));
        list.AddAtTail("B");
        Assert.Throws<IndexOutOfRangeException>(() => list.AddAt("C", 5));
    }

    [Test]
    public void AddAtStart () {
        LinkedList list = new ();
        list.AddAtTail("A");
        list.AddAtTail("D");
        list.AddAtTail("H");
        list.AddAt("B", 0);
        Assert.That(list.Head.Data, Is.EqualTo("B"));
        list.AddAt("C", 0);
        Assert.That(list.Head.Data, Is.EqualTo("C"));
        list.AddAt("E", 0);
        Assert.That(list.Head.Data, Is.EqualTo("E"));
    }

    [Test]
    public void AddAtEnd () {
        LinkedList list = new ();
        list.AddAtTail("A");
        list.AddAtTail("D");
        list.AddAtTail("H");
        list.AddAt("B", 3);
        Assert.That(list.Tail.Data, Is.EqualTo("B"));
        list.AddAt("C", 4);
        Assert.That(list.Tail.Data, Is.EqualTo("C"));
        list.AddAt("E", 5);
        Assert.That(list.Tail.Data, Is.EqualTo("E"));
    }

    [Test]
    public void AddAtMiddle () {
        LinkedList list = new ();
        list.AddAtTail("A");
        list.AddAtTail("D");
        list.AddAtTail("H");
        list.AddAt("B", 1);
        Assert.That(list.Get(1).Data, Is.EqualTo("B"));
        list.AddAt("C", 2);
        Assert.That(list.Get(2).Data, Is.EqualTo("C"));
        list.AddAt("E", 4);
        Assert.That(list.Get(4).Data, Is.EqualTo("E"));
        list.AddAt("F", 5);
        Assert.That(list.Get(5).Data, Is.EqualTo("F"));
        list.AddAt("G", 6);
        Assert.That(list.Get(6).Data, Is.EqualTo("G"));
    }

    [Test]
    public void DeleteAtHeadAll() {
        LinkedList list = new();
        list.AddAtTail("A");
        list.AddAtTail("B");
        list.AddAtTail("C");
        list.DeleteAtHead();
        Assert.That(list.Head.Data, Is.EqualTo("B"));
        list.DeleteAtHead();
        Assert.That(list.Head.Data, Is.EqualTo("C"));
        list.DeleteAtHead();
        Assert.Throws<IndexOutOfRangeException>(() => list.DeleteAtHead());
    }

    [Test]
    public void DeleteAtTailAll() {
        LinkedList list = new(); 
        Assert.Throws<IndexOutOfRangeException>(() => list.DeleteAtTail());
        list.AddAtTail("A");
        list.AddAtTail("B");
        list.AddAtTail("C");
        list.DeleteAtTail();
        Assert.That(list.Tail.Data, Is.EqualTo("B"));
        list.DeleteAtTail();
        Assert.That(list.Tail.Data, Is.EqualTo("A"));
        list.DeleteAtTail();
        Assert.Throws<IndexOutOfRangeException>(() => list.DeleteAtTail());
    }

    [Test]
    public void DeleteAt() {
        LinkedList list = new();
        Assert.Throws<IndexOutOfRangeException>(() => list.DeleteAt(0));
        Assert.Throws<IndexOutOfRangeException>(() => list.DeleteAt(-5));
        Assert.Throws<IndexOutOfRangeException>(() => list.DeleteAt(10));
        list.AddAtTail("A");
        list.AddAtTail("B");
        list.AddAtTail("C");
        list.AddAtTail("D");
        list.AddAtTail("F");
        list.AddAtTail("G");
        list.DeleteAt(2); 
        Assert.That(list.Get(2).Data, Is.EqualTo("D"));
        list.DeleteAt(3); 
        Assert.That(list.Get(3).Data, Is.EqualTo("G"));
    }
}