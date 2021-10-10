using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public ActionType Type => type;
    public LamaColor Color => color;

    private ActionType type;
    private LamaColor color;

    public Action(ActionType type, LamaColor color)
    {
        this.type = type;
        this.color = color;
    }
}
