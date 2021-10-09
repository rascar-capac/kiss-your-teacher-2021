using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksManager : MonoBehaviour
{
    public static TasksManager Instance => instance;
    public Task[] CurrentTasks => currentTasks;

    // [SerializeField] private float countChance;
    // [SerializeField] private float colorChance;
    // [SerializeField] private float opponentChance;
    private Task[] currentTasks;
    private bool mustDrawNewTasks;
    private static TasksManager instance;



    public void CompleteTask(int index)
    {
        currentTasks[index] = null;
        mustDrawNewTasks = true;
    }



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentTasks = new Task[3];
        for (int i = 0; i < currentTasks.Length; i++)
        {
            currentTasks[i] = DrawRandomTask();
        }
        UIManager.Instance.UpdateTasks(currentTasks);
    }

    private void Update()
    {
        if (!mustDrawNewTasks) return;

        for (int i = 0; i < currentTasks.Length; i++)
        {
            if (currentTasks[i] == null)
            {
                currentTasks[i] = DrawRandomTask();
            }
        }
        mustDrawNewTasks = false;
        UIManager.Instance.UpdateTasks(currentTasks);
    }

    private Task DrawRandomTask()
    {
        return DataManager.Instance.Tasks[Random.Range(0, DataManager.Instance.Tasks.Count)];
    }
}

public enum TaskType
{
    BELOW,
    ABOVE,
    LEAST_COLOR,
    MOST_COLOR,
    LESS_OPPONENT,
    MORE_OPPONENT,
}
