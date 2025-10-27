using UnityEngine;

public class PriorityQueue<T>
{
    public Node2<T> Head;
    public Node2<T> Tail;
    public int count;
    public void Enqueue(T node, int priority = 0)
    {
        Node2<T> NewNode = new(node, priority);
        if (Head == null && Tail == null)
        {
            Head = NewNode;
            Tail = NewNode;
            count++;
            return;
        }
        CheckValues(Head, NewNode);
    }

private void CheckValues(Node2<T> current, Node2<T> newNode, int depth = 0)
    {
        if (depth > count) return;
        if (newNode.Priority >= current.Priority)
        {
            if (current == Head)
            {
                newNode.SetNext(current);
                current.SetPrev(newNode);
                Head = newNode;
                count++;
                return;
            }
            newNode.SetNext(current);
            newNode.SetPrev(current.Prev);
            current.Prev.SetNext(newNode);
            current.SetPrev(newNode);
            count++;
            return;
        }
        if (current == Tail)
        {
            newNode.SetPrev(current);
            current.SetNext(newNode);
            Tail = newNode;
            count++;
            return;
        }
        CheckValues(current.Next, newNode, depth + 1);
    }
    public T Dequeue()
    {
        if (count == 0) return default;
        T value = Head.Value;
        if (count > 1)
        {
            Head = Head.Next;
            Head.SetPrev(null);
        }
        else
        {
            Head = null;
            Tail = null;
        }
        count--;
        return value;
    }
    public T Peek()
    {
        return Head.Value;
    }
    public int Count => count;
}