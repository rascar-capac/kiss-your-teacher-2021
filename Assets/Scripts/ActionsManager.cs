using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public static ActionsManager Instance => instance;
    public Action[] CurrentActions => currentActions;

    // [SerializeField] private float additionChance;
    // [SerializeField] private float transferChance;
    // [SerializeField] private float colorSwitchChance;
    // [SerializeField] private float rerollChance;
    // [SerializeField] private float exchangeChance;
    private Action[] currentActions;
    private bool mustDrawNewActions;
    private static ActionsManager instance;



    public void SelectAction(int index)
    {
        currentActions[index] = null;
        mustDrawNewActions = true;
    }



    private void Awake()
    {
        instance = this;
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

    private void Update()
    {
        if (!mustDrawNewActions) return;

        for (int i = 0; i < currentActions.Length; i++)
        {
            if (currentActions[i] == null)
            {
                currentActions[i] = DrawRandomAction();
            }
        }
        mustDrawNewActions = false;
        UIManager.Instance.UpdateActions(currentActions);
    }

    private Action DrawRandomAction()
    {
        return DataManager.Instance.Actions[Random.Range(0, DataManager.Instance.Actions.Count)];
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
