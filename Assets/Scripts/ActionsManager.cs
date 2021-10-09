using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsManager : MonoBehaviour
{
    public Action[] CurrentActions => currentActions;

    [SerializeField] private Image action0;
    [SerializeField] private Image action1;
    [SerializeField] private Image action2;
    [SerializeField] private Transform spire;
    [SerializeField] private Sprite additionSprite;
    [SerializeField] private Sprite transferSprite;
    [SerializeField] private Sprite colorSwitchSprite;
    [SerializeField] private Sprite rerollSprite;
    [SerializeField] private Sprite exchangeSprite;
    // [SerializeField] private float additionChance;
    // [SerializeField] private float transferChance;
    // [SerializeField] private float colorSwitchChance;
    // [SerializeField] private float rerollChance;
    // [SerializeField] private float exchangeChance;
    private Action[] currentActions;
    [SerializeField] private PaddockManager paddockManager;



    public void PressKey()
    {
        if (-spire.transform.rotation.z < 120f)
        {
            SelectAction(0);
        }
        else if (-spire.transform.rotation.z < 240f)
        {
            SelectAction(1);
        }
        else
        {
            SelectAction(2);
        }
    }

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
        switch (currentActions[0].Type)
        {
            case ActionType.ADDITION:
                action0.sprite = additionSprite;
                break;
            case ActionType.TRANSFER:
                action0.sprite = transferSprite;
                break;
            case ActionType.COLOR_SWITCH:
                action0.sprite = colorSwitchSprite;
                break;
            case ActionType.REROLL:
                action0.sprite = rerollSprite;
                break;
            case ActionType.EXCHANGE:
                action0.sprite = exchangeSprite;
                break;
        }
        switch (currentActions[1].Type)
        {
            case ActionType.ADDITION:
                action1.sprite = additionSprite;
                break;
            case ActionType.TRANSFER:
                action1.sprite = transferSprite;
                break;
            case ActionType.COLOR_SWITCH:
                action1.sprite = colorSwitchSprite;
                break;
            case ActionType.REROLL:
                action1.sprite = rerollSprite;
                break;
            case ActionType.EXCHANGE:
                action1.sprite = exchangeSprite;
                break;
        }
        switch (currentActions[2].Type)
        {
            case ActionType.ADDITION:
                action2.sprite = additionSprite;
                break;
            case ActionType.TRANSFER:
                action2.sprite = transferSprite;
                break;
            case ActionType.COLOR_SWITCH:
                action2.sprite = colorSwitchSprite;
                break;
            case ActionType.REROLL:
                action2.sprite = rerollSprite;
                break;
            case ActionType.EXCHANGE:
                action2.sprite = exchangeSprite;
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
