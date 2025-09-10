using UnityEngine;
using System.Collections.Generic;


namespace LequernaqueGalvez
{
    public class CustomDoubleLinkedList
    {
        public CustomNode Head { get; private set; }
        public CustomNode Tail { get; private set; }
        public CustomNode Peak { get; private set; }
        public int Count { get; private set; }

        public void Add(int turnNumber, List<IEntity> entities)
        {
            var newNode = new CustomNode(turnNumber, entities);
            if (Peak != Tail)
            {
                var node = Peak?.Next;
                while (node != null)
                {
                    var next = node.Next;
                    node.Prev = null;
                    node.Next = null;
                    node = next;
                    Count--;
                }
                if (Peak != null) Peak.Next = null;
                Tail = Peak;
            }

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                Peak = newNode;
                Count = 1;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
                Peak = newNode;
                Count++;
            }
        }

        public void MoveToPrev()
        {
            if (Peak?.Prev != null) Peak = Peak.Prev;
        }

        public void MoveToNext()
        {
            if (Peak?.Next != null) Peak = Peak.Next;
        }
    }
}

