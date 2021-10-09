using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public TaskType Type => type;
    public int Value => value;
    public LamaColor Color => color;
    public int Gain => gain;

    private TaskType type;
    private int value;
    private LamaColor color;
    private int gain;

    public Task(string type, int value, string color, int gain)
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
        this.gain = gain;
    }
}
