using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionsManager : MonoBehaviour
{
    public Action[] CurrentActions => currentActions;

    [SerializeField] private TextMeshProUGUI action0;
    [SerializeField] private TextMeshProUGUI action1;
    [SerializeField] private TextMeshProUGUI action2;
    // [SerializeField] private float additionChance;
    // [SerializeField] private float transferChance;
    // [SerializeField] private float colorSwitchChance;
    // [SerializeField] private float rerollChance;
    // [SerializeField] private float exchangeChance;
    private Action[] currentActions;
    [SerializeField] private PaddockManager paddockManager;



    public void SelectAction(int index)
    {
        ApplyAction(currentActions[index]);
        for (int i = 0; i < currentActions.Length; i++)
        {
            currentActions[i] = DrawRandomAction();
        }
        UpdateActions();
        TasksManager.Instance.CheckTasks();
    }



    private void Start()
    {
        currentActions = new Action[3];
        for (int i = 0; i < currentActions.Length; i++)
        {
            currentActions[i] = DrawRandomAction();
        }
        UpdateActions();
    }

    private Action DrawRandomAction()
    {
        return DataManager.Instance.Actions[Random.Range(0, DataManager.Instance.Actions.Count)];
    }

    private void ApplyAction(Action action)
    {
        switch (action.Type)
        {
            case ActionType.ADDITION:
                paddockManager.Add(action.Value, action.Color);
                break;
            case ActionType.TRANSFER:
                paddockManager.Transfer(action.Value, action.Color);
                break;
            case ActionType.COLOR_SWITCH:
                paddockManager.SwitchColors();
                break;
            case ActionType.REROLL:
                paddockManager.Reroll();
                break;
            case ActionType.EXCHANGE:
                paddockManager.Exchange(action.Color);
                break;
        }
    }

    private void UpdateActions()
    {
        action0.text = FormatActionButton(currentActions[0]);
        action1.text = FormatActionButton(currentActions[1]);
        action2.text = FormatActionButton(currentActions[2]);
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
}

public enum ActionType
{
    ADDITION,
    TRANSFER,
    COLOR_SWITCH,
    REROLL,
    EXCHANGE,
}
