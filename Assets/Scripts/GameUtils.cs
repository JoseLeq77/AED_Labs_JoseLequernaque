using UnityEngine;

namespace LequernaqueGalvez
{
    public static class GameUtils
    {
        public static float Distance(float x1, float y1, float x2, float y2)
        {
            return Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2));
        }
    }
}
    
