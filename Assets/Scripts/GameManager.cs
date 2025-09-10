using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace LequernaqueGalvez
{
    public class GameManager : MonoBehaviour
    {
        public Button AddTurnButton;
        public Button PrevTurnButton;
        public Button NextTurnButton;
        public TextMeshProUGUI InfoText;
        public Transform Player;

        private CustomDoubleLinkedList history = new CustomDoubleLinkedList();
        private int currentTurn = 0;

        void Start()
        {
            UpdateInfo();
        }

        public void AddTurn()
        {
            currentTurn++;

            Vector3 newPos = GetRandomPosition();
            Player.position = newPos;

            List<IEntity> entities = new List<IEntity> { new Entity("Player", newPos) };
            history.Add(currentTurn, entities);
            UpdateInfo();
        }

        public void MovePrev()
        {
            history.MoveToPrev();
            if (history.Peak != null)
            {
                Player.position = history.Peak.Entities[0].Position;
            }
            UpdateInfo();
        }

        public void MoveNext()
        {
            history.MoveToNext();
            if (history.Peak != null)
            {
                Player.position = history.Peak.Entities[0].Position;
            }
            UpdateInfo();
        }

        void UpdateInfo()
        {
            if (history.Peak == null)
            {
                InfoText.text = "No Hay Turnos";
            }
            else
            {
                CustomNode node = history.Peak;
                IEntity ent = node.Entities[0];
                InfoText.text = "Turno " + node.TurnNumber + " - " + ent.Name + ": " + ent.Position;
            }
        }

        Vector3 GetRandomPosition()
        {
            float x = Random.Range(-7.6f, 7.6f);
            float y = Random.Range(-1.3f, 3.7f);
            return new Vector3(x, y, Player.position.z);
        }
    }
}
