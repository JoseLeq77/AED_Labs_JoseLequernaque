using UnityEngine;

public class Node2<T>
{
    #region Settings

    private T value;
    private int priority;
    private Node2<T> next;
    private Node2<T> prev;

    #endregion

    #region Setters

    public Node2(T _value, int _priority = 0)
    {
        value = _value;
        priority = _priority;
        next = null;
        prev = null;
    }

    public void SetNext(Node2<T> next)
    {
        this.next = next;
    }

    public void SetPrev(Node2<T> prev)
    {
        this.prev = prev;
    }

    #endregion

    public void Clear()
    {
        next = null;
        prev = null;
    }

    #region Getters

    public T Value => value;
    public Node2<T> Next => next;
    public Node2<T> Prev => prev;
    public int Priority => priority;

    #endregion
}
