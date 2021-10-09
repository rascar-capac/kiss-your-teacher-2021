using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public Action[] CurrentActions => currentActions;

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
        UIManager.Instance.UpdateActions(currentActions);
        TasksManager.Instance.CheckTasks();
    }



    private void Start()
    {
        currentActions = new Action[3];
        for (int i = 0; i < currentActions.Length; i++)
        {
            currentActions[i] = DrawRandomAction();
        }
        UIManager.Instance.UpdateActions(currentActions);
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
}

public enum ActionType
{
    ADDITION,
    TRANSFER,
    COLOR_SWITCH,
    REROLL,
    EXCHANGE,
}
