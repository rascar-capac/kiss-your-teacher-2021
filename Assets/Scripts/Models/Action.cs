using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public ActionType Type => type;
    public LamaColor Color => color;

    private ActionType type;
    private LamaColor color;

    public Action(string type, string color)
    {
        switch (type)
        {
            case "addition":
                this.type = ActionType.ADDITION;
                break;
            case "substraction":
                this.type = ActionType.SUBSTRACTION;
                break;
            case "transfer":
                this.type = ActionType.TRANSFER;
                break;
            case "color switch":
                this.type = ActionType.COLOR_SWITCH;
                break;
            case "reroll":
                this.type = ActionType.REROLL;
                break;
            case "exchange":
                this.type = ActionType.EXCHANGE;
                break;
        }
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
            default:
                this.color = LamaColor.NONE;
                break;
        }
    }
}
