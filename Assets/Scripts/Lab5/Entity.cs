using UnityEngine;

namespace LequernaqueGalvez
{
    public interface IEntity
    {
        string Name { get; }
        Vector3 Position { get; set; }
    }

    public class Entity : IEntity
    {
        public string Name { get; private set; }
        public Vector3 Position { get; set; }

        public Entity(string name, Vector3 position)
        {
            Name = name;
            Position = position;
        }
    }
}

