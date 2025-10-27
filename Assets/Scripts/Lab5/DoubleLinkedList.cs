using UnityEngine;

public class DoubleLinkedList<T>
{
    public Node<T> Head;
    public Node<T> Tail;
    public int Count;

    #region Add

    public void AddFirst(T dato)
    {
        Node<T> newNode = new Node<T>(dato);

        if (Head == null) 
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.SetNext(Head);
            Head.SetPrev(newNode);
            Head = newNode;
        }

        Count++;
    }

    public void AddLast(T dato)
    {
        Node<T> newNode = new Node<T>(dato);

        if (Tail == null) 
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.SetNext(newNode);
            newNode.SetPrev(Tail);
            Tail = newNode;
        }

        Count++;
    }

    #endregion

    #region Find

    public Node<T> Find(T target, Node<T> start, int depth = 1000)
    {
        if (start == null || depth <= 0) return null;

        if (start.Value.Equals(target)) return start;

        return Find(target, start.Next, depth - 1);
    }

    #endregion

    #region Read

    public void ReadForward(Node<T> value, int depth = 1000)
    {
        if (value == null || depth <= 0) return;

        Debug.Log(value.Value.ToString());

        if (value.Next != null)
        {
            ReadForward(value.Next, depth - 1);
        }
    }

    public void ReadBackward(Node<T> value, int depth = 1000)
    {
        if (value == null || depth <= 0) return;

        Debug.Log(value.Value.ToString());

        if (value.Prev != null)
        {
            ReadBackward(value.Prev, depth - 1);
        }
    }

    #endregion

    #region Insert

    public void InsertAfter(Node<T> target, Node<T> value)
    {
        Node<T> temp = Find(target.Value, Head);
        if (temp == null) return;

        if (temp.Next != null)
        {
            value.SetNext(temp.Next);
            value.SetPrev(temp);

            temp.Next.SetPrev(value);
            temp.SetNext(value);
        }
        else
        {
            value.SetPrev(temp);
            value.SetNext(null);

            temp.SetNext(value);
            Tail = value;
        }

        Count++;
    }

    #endregion

    #region Delete

    public void Delete(Node<T> target)
    {
        if (target == null) return;

        if (Head == target && Tail == target)
        {
            Head = null;
            Tail = null;
            Count--;
            return;
        }

        if (target == Head)
        {
            Head = Head.Next;
            if (Head != null)
            {
                Head.SetPrev(null);
            }
            Count--;
            return;
        }

        if (target == Tail)
        {
            Tail = Tail.Prev;
            if (Tail != null)
            {
                Tail.SetNext(null);
            }
            Count--;
            return;
        }

        Node<T> temp = Find(target.Value, Head);
        if (temp != null)
        {
            temp.Prev.SetNext(temp.Next);
            temp.Next.SetPrev(temp.Prev);

            temp.SetNext(null);
            temp.SetPrev(null);

            Count--;
        }
    }

    #endregion
}
