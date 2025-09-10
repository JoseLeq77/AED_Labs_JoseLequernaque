using UnityEngine;
using System.Collections.Generic;


namespace LequernaqueGalvez
{
    public class CustomNode
    {
        public int TurnNumber { get; private set; }
        public List<IEntity> Entities { get; private set; }
        public CustomNode Prev { get; set; }
        public CustomNode Next { get; set; }

        public CustomNode(int turnNumber, List<IEntity> entities)
        {
            TurnNumber = turnNumber;
            Entities = entities;
            Prev = null;
            Next = null;
        }
    }
}

