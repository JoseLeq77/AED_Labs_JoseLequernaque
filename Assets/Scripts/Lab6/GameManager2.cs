using UnityEngine;
using TMPro;

public enum TaskType
{
    Analyze,
    Transport,
    Repair,
    Report,
    Upgrade,
    Secure,
    Diagnose,
    Calibrate
}

public class GameManager2 : MonoBehaviour
{
    public PriorityQueue<TaskType> tasks = new PriorityQueue<TaskType>();
    public TextMeshProUGUI currentTaskText;
    public TextMeshProUGUI nextTaskText;

    private void Start()
    {
        tasks.Enqueue(TaskType.Analyze, 8);
        tasks.Enqueue(TaskType.Transport, 1);
        tasks.Enqueue(TaskType.Repair, 4);
        tasks.Enqueue(TaskType.Report, 7);
        tasks.Enqueue(TaskType.Upgrade, 2);
        tasks.Enqueue(TaskType.Secure, 5);
        tasks.Enqueue(TaskType.Diagnose, 6);
        tasks.Enqueue(TaskType.Calibrate, 10);
        UpdateTaskTexts();
    }
    private void UpdateTaskTexts()
    {
        if (tasks.Count > 0)
        {
            object current = tasks.Head != null ? tasks.Head.Value : null;
            object next = (tasks.Head != null && tasks.Head.Next != null) ? tasks.Head.Next.Value : null;

            currentTaskText.text = "Current task: " + (current != null ? current.ToString() : "None");
            nextTaskText.text = "Next task: " + (next != null ? next.ToString() : "None");
        }
        else
        {
            currentTaskText.text = "No current task";
            nextTaskText.text = "No upcoming tasks";
        }
    }

    public void CompleteTask()
    {
        if (tasks.Count > 0)
        {
            object completed = tasks.Dequeue();
            currentTaskText.text = "Task completed: " + completed;
            UpdateTaskTexts();
        }
        else
        {
            currentTaskText.text = "All tasks have been completed";
            nextTaskText.text = "No upcoming tasks";
        }
    }
}
