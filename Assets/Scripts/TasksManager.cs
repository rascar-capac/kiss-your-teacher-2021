using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TasksManager : MonoBehaviour
{
    public static TasksManager Instance => instance;
    public Task[] CurrentTasks => currentTasks;

    [SerializeField] private TextMeshProUGUI task0;
    [SerializeField] private TextMeshProUGUI task1;
    [SerializeField] private TextMeshProUGUI task2;
    // [SerializeField] private float countChance;
    // [SerializeField] private float colorChance;
    // [SerializeField] private float opponentChance;
    private Task[] currentTasks;
    private bool mustDrawNewTasks;
    private static TasksManager instance;
    [SerializeField] private PaddockManager p1PaddockManager;
    [SerializeField] private PaddockManager p2PaddockManager;



    public void CheckTasks()
    {
        for (int i = 0; i < currentTasks.Length; i++)
        {
            switch (currentTasks[i].Type)
            {
                case TaskType.ABOVE:
                    int p1Count = 0;
                    int p2Count = 0;
                    if (currentTasks[i].Color != LamaColor.NONE)
                    {
                        foreach (LamaState lama in p1PaddockManager.Lamas)
                        {
                            if (lama.Color == currentTasks[i].Color)
                            {
                                p1Count++;
                            }
                        }
                        foreach (LamaState lama in p2PaddockManager.Lamas)
                        {
                            if (lama.Color == currentTasks[i].Color)
                            {
                                p2Count++;
                            }
                        }
                    }
                    else
                    {
                        p1Count = p1PaddockManager.Lamas.Count;
                        p2Count = p2PaddockManager.Lamas.Count;
                    }
                    if (p1Count > currentTasks[i].Value)
                    {
                        CompleteTask(currentTasks[i], p1PaddockManager);
                    }
                    else if (p2Count > currentTasks[i].Value)
                    {
                        CompleteTask(currentTasks[i], p2PaddockManager);
                    }
                    break;
                case TaskType.BELOW:
                    p1Count = 0;
                    p2Count = 0;
                    if (currentTasks[i].Color != LamaColor.NONE)
                    {
                        foreach (LamaState lama in p1PaddockManager.Lamas)
                        {
                            if (lama.Color == currentTasks[i].Color)
                            {
                                p1Count++;
                            }
                        }
                        foreach (LamaState lama in p2PaddockManager.Lamas)
                        {
                            if (lama.Color == currentTasks[i].Color)
                            {
                                p2Count++;
                            }
                        }
                    }
                    else
                    {
                        p1Count = p1PaddockManager.Lamas.Count;
                        p2Count = p2PaddockManager.Lamas.Count;
                    }
                    if (p1Count < currentTasks[i].Value)
                    {
                        CompleteTask(currentTasks[i], p1PaddockManager);
                    }
                    else if (p2Count < currentTasks[i].Value)
                    {
                        CompleteTask(currentTasks[i], p2PaddockManager);
                    }
                    break;
                case TaskType.LEAST_COLOR:
                    int[] colorCounts = new int[4];
                    LamaColor[] colors = new LamaColor[4];
                    foreach (LamaState lama in p1PaddockManager.Lamas)
                    {
                        switch (lama.Color)
                        {
                            case LamaColor.BLUE:
                                colorCounts[0]++;
                                colors[0] = LamaColor.BLUE;
                                break;
                            case LamaColor.RED:
                                colorCounts[1]++;
                                colors[1] = LamaColor.RED;
                                break;
                            case LamaColor.GREEN:
                                colorCounts[2]++;
                                colors[2] = LamaColor.GREEN;
                                break;
                            case LamaColor.YELLOW:
                                colorCounts[3]++;
                                colors[3] = LamaColor.YELLOW;
                                break;
                        }
                    }
                    int minValue = int.MaxValue;
                    LamaColor minColor = LamaColor.NONE;
                    for (int j = 0; j < 4; j++)
                    {
                        if (colorCounts[j] < minValue)
                        {
                            minValue = colorCounts[j];
                            minColor = colors[j];
                        }
                    }

                    if (minColor == currentTasks[i].Color)
                    {
                        CompleteTask(currentTasks[i], p1PaddockManager);
                    }

                    colorCounts = new int[4];
                    colors = new LamaColor[4];
                    foreach (LamaState lama in p2PaddockManager.Lamas)
                    {
                        switch (lama.Color)
                        {
                            case LamaColor.BLUE:
                                colorCounts[0]++;
                                colors[0] = LamaColor.BLUE;
                                break;
                            case LamaColor.RED:
                                colorCounts[1]++;
                                colors[1] = LamaColor.RED;
                                break;
                            case LamaColor.GREEN:
                                colorCounts[2]++;
                                colors[2] = LamaColor.GREEN;
                                break;
                            case LamaColor.YELLOW:
                                colorCounts[3]++;
                                colors[3] = LamaColor.YELLOW;
                                break;
                        }
                    }
                    minValue = int.MaxValue;
                    minColor = LamaColor.NONE;
                    for (int j = 0; j < 4; j++)
                    {
                        if (colorCounts[j] < minValue)
                        {
                            minValue = colorCounts[j];
                            minColor = colors[j];
                        }
                    }

                    if (minColor == currentTasks[i].Color)
                    {
                        CompleteTask(currentTasks[i], p2PaddockManager);
                    }
                    break;
                case TaskType.MOST_COLOR:
                    colorCounts = new int[4];
                    colors = new LamaColor[4];
                    foreach (LamaState lama in p1PaddockManager.Lamas)
                    {
                        switch (lama.Color)
                        {
                            case LamaColor.BLUE:
                                colorCounts[0]++;
                                colors[0] = LamaColor.BLUE;
                                break;
                            case LamaColor.RED:
                                colorCounts[1]++;
                                colors[1] = LamaColor.RED;
                                break;
                            case LamaColor.GREEN:
                                colorCounts[2]++;
                                colors[2] = LamaColor.GREEN;
                                break;
                            case LamaColor.YELLOW:
                                colorCounts[3]++;
                                colors[3] = LamaColor.YELLOW;
                                break;
                        }
                    }
                    int maxValue = 0;
                    LamaColor maxColor = LamaColor.NONE;
                    for (int j = 0; j < 4; j++)
                    {
                        if (colorCounts[j] > maxValue)
                        {
                            maxValue = colorCounts[j];
                            maxColor = colors[j];
                        }
                    }

                    if (maxColor == currentTasks[i].Color)
                    {
                        CompleteTask(currentTasks[i], p1PaddockManager);
                    }

                    colorCounts = new int[4];
                    colors = new LamaColor[4];
                    foreach (LamaState lama in p2PaddockManager.Lamas)
                    {
                        switch (lama.Color)
                        {
                            case LamaColor.BLUE:
                                colorCounts[0]++;
                                colors[0] = LamaColor.BLUE;
                                break;
                            case LamaColor.RED:
                                colorCounts[1]++;
                                colors[1] = LamaColor.RED;
                                break;
                            case LamaColor.GREEN:
                                colorCounts[2]++;
                                colors[2] = LamaColor.GREEN;
                                break;
                            case LamaColor.YELLOW:
                                colorCounts[3]++;
                                colors[3] = LamaColor.YELLOW;
                                break;
                        }
                    }
                    maxValue = 0;
                    maxColor = LamaColor.NONE;
                    for (int j = 0; j < 4; j++)
                    {
                        if (colorCounts[j] > maxValue)
                        {
                            maxValue = colorCounts[j];
                            maxColor = colors[j];
                        }
                    }

                    if (maxColor == currentTasks[i].Color)
                    {
                        CompleteTask(currentTasks[i], p2PaddockManager);
                    }
                    break;
            }
        }
    }

    public void CompleteTask(Task completedTask, PaddockManager paddockManager)
    {
        if (paddockManager == p1PaddockManager)
        {
            GameManager.Instance.IncreaseP1Score(completedTask.Gain);
        }
        else
        {
            GameManager.Instance.IncreaseP2Score(completedTask.Gain);
        }
        mustDrawNewTasks = true;
        for (int i = 0; i < currentTasks.Length; i++)
        {
            if (currentTasks[i] == completedTask)
            {
                currentTasks[i] = DrawRandomTask();
            }
        }
        UpdateTasks();
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
        UpdateTasks();
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
        UpdateTasks();
    }

    private Task DrawRandomTask()
    {
        return DataManager.Instance.Tasks[Random.Range(0, DataManager.Instance.Tasks.Count)];
    }

    private void UpdateTasks()
    {
        task0.text = FormatTask(currentTasks[0]);
        task1.text = FormatTask(currentTasks[1]);
        task2.text = FormatTask(currentTasks[2]);
    }

    private string FormatTask(Task task)
    {
        string text = "";
        switch (task.Type)
        {
            case TaskType.ABOVE:
                text += "above";
                break;
            case TaskType.BELOW:
                text += "below";
                break;
            case TaskType.LEAST_COLOR:
                text += "the least in";
                break;
            case TaskType.MOST_COLOR:
                text += "the most in";
                break;
        }

        if (task.Value != -1)
        {
            text += $" {task.Value}";
        }

        if (task.Color != LamaColor.NONE)
        {
            text += $" {task.Color}";
        }
        else
        {
            text += " ALL";
        }

        return text;
    }
}

public enum TaskType
{
    BELOW,
    ABOVE,
    LEAST_COLOR,
    MOST_COLOR,
}
