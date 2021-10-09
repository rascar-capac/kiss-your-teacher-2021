using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public TaskType Type => type;
    public float Value => value;
    public LamaColor Color => color;

    private TaskType type;
    private float value;
    private LamaColor color;

    public Task(string type, float value, string color)
    {
        switch (type)
        {
            case "below":
                this.type = TaskType.BELOW;
                break;
            case "above":
                this.type = TaskType.ABOVE;
                break;
            case "least color":
                this.type = TaskType.LEAST_COLOR;
                break;
            case "most color":
                this.type = TaskType.MOST_COLOR;
                break;
            case "less than opponent":
                this.type = TaskType.LESS_OPPONENT;
                break;
            case "more than opponent":
                this.type = TaskType.MORE_OPPONENT;
                break;
        }
        this.value = value;
        switch (color)
        {
            case "blue":
                this.color = LamaColor.BLUE;
                break;
            case "green":
                this.color = LamaColor.GREEN;
                break;
            case "red":
                this.color = LamaColor.RED;
                break;
            case "yellow":
                this.color = LamaColor.YELLOW;
                break;
        }
    }
}
