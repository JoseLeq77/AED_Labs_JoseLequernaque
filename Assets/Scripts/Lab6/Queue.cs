using UnityEngine;

public class Queue<T>
{
    public Node2<T> Head;
    public Node2<T> Tail;
    public int count;
    public void Enqueue(T node)
    {
        Node2<T> NewNode = new(node);
        if (Head == null && Tail == null)
        {
            Head = NewNode;
            Tail = NewNode;
        count++;
            return;
        }
        NewNode.SetPrev(Tail);
        Tail.SetNext(NewNode);
        Tail = NewNode;
        count++;
    }
    public T Dequeue()
    {
        if (count == 0) return default;
        Node2<T> temp = new(Head.Value, Head.Priority);
        if (count > 1)
        {
            Node2<T> NewHead = Head.Next;
            NewHead.Prev.SetNext(null);
            NewHead.SetPrev(null);
            Head = NewHead;
        }
        else
        {
            Head.Clear();
            Head = null;
            Tail.Clear();
            Tail = null;
        }
        count--;
        return temp.Value;
    }
    public T Peek()
    {
        return Head.Value;
    }
    public int Count => count;
}