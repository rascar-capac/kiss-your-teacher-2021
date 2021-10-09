using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance => instance;

    [SerializeField] private TextMeshProUGUI action0;
    [SerializeField] private TextMeshProUGUI action1;
    [SerializeField] private TextMeshProUGUI action2;
    [SerializeField] private TextMeshProUGUI task0;
    [SerializeField] private TextMeshProUGUI task1;
    [SerializeField] private TextMeshProUGUI task2;
    private static UIManager instance;



    private void Awake()
    {
        instance = this;
    }



    public void UpdateActions(Action[] currentActions)
    {
        action0.text = FormatActionButton(currentActions[0]);
        action1.text = FormatActionButton(currentActions[1]);
        action2.text = FormatActionButton(currentActions[2]);
    }

    public void UpdateTasks(Task[] currentTasks)
    {
        task0.text = FormatTask(currentTasks[0]);
        task1.text = FormatTask(currentTasks[1]);
        task2.text = FormatTask(currentTasks[2]);
    }



    private string FormatActionButton(Action action)
    {
        string text = "";
        switch (action.Type)
        {
            case ActionType.ADDITION:
                text += "add";
                break;
            case ActionType.TRANSFER:
                text += "transfer";
                break;
            case ActionType.COLOR_SWITCH:
                text += "switch colors";
                break;
            case ActionType.EXCHANGE:
                text += "exchange";
                break;
            case ActionType.REROLL:
                text += "reroll";
                break;
        }

        if (action.Value != -1)
        {
            text += $" {action.Value}";
        }

        if (action.Color != LamaColor.NONE)
        {
            text += $" {action.Color}";
        }
        else
        {
            text += " ALL";
        }

        return text;
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
