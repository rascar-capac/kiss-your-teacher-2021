using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionsManager : MonoBehaviour
{
    public Action[] CurrentActions => currentActions;

    [SerializeField] private Image action0;
    [SerializeField] private Image action1;
    [SerializeField] private Image action2;
    [SerializeField] private Transform spire;
    [SerializeField] private Sprite additionSprite;
    [SerializeField] private Sprite substractionSprite;
    [SerializeField] private Sprite transferSprite;
    [SerializeField] private Sprite colorSwitchSprite;
    [SerializeField] private Sprite rerollSprite;
    [SerializeField] private Sprite exchangeSprite;
    [SerializeField] private Color redColor;
    [SerializeField] private Color blueColor;
    [SerializeField] private Color greenColor;
    [SerializeField] private Color yellowColor;
    [SerializeField] private TextMeshProUGUI value0;
    [SerializeField] private TextMeshProUGUI value1;
    [SerializeField] private TextMeshProUGUI value2;
    [SerializeField] private Material randomColorMaterial;
    // [SerializeField] private float additionChance;
    // [SerializeField] private float substractionChance;
    // [SerializeField] private float transferChance;
    // [SerializeField] private float colorSwitchChance;
    // [SerializeField] private float rerollChance;
    // [SerializeField] private float exchangeChance;
    private Action[] currentActions;
    [SerializeField] private PaddockManager paddockManager;



    public void PressKey()
    {
        if (spire.transform.rotation.eulerAngles.z < 120f)
        {
            SelectAction(2);
        }
        else if (spire.transform.rotation.eulerAngles.z < 240f)
        {
            SelectAction(1);
        }
        else
        {
            SelectAction(0);
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
            case ActionType.SUBSTRACTION:
                paddockManager.Substract(action.Value, action.Color);
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
            case ActionType.SUBSTRACTION:
                action0.sprite = substractionSprite;
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
        switch (currentActions[0].Color)
        {
            case LamaColor.RED:
                action0.color = redColor;
                break;
            case LamaColor.BLUE:
                action0.color = blueColor;
                break;
            case LamaColor.GREEN:
                action0.color = greenColor;
                break;
            case LamaColor.YELLOW:
                action0.color = yellowColor;
                break;
            default:
                action0.color = Color.black;
                break;
        }
        if (currentActions[0].Value != -1)
        {
            value0.gameObject.SetActive(true);
            value0.text = currentActions[0].Value.ToString();
        }
        else
        {
            value0.gameObject.SetActive(false);
        }
        switch (currentActions[1].Type)
        {
            case ActionType.ADDITION:
                action1.sprite = additionSprite;
                break;
            case ActionType.SUBSTRACTION:
                action1.sprite = substractionSprite;
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
        switch (currentActions[1].Color)
        {
            case LamaColor.RED:
                action1.color = redColor;
                break;
            case LamaColor.BLUE:
                action1.color = blueColor;
                break;
            case LamaColor.GREEN:
                action1.color = greenColor;
                break;
            case LamaColor.YELLOW:
                action1.color = yellowColor;
                break;
            default:
                action1.color = Color.black;
                break;
        }
        if (currentActions[1].Value != -1)
        {
            value1.gameObject.SetActive(true);
            value1.text = currentActions[1].Value.ToString();
        }
        else
        {
            value1.gameObject.SetActive(false);
        }
        switch (currentActions[2].Type)
        {
            case ActionType.ADDITION:
                action2.sprite = additionSprite;
                break;
            case ActionType.SUBSTRACTION:
                action2.sprite = substractionSprite;
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
        switch (currentActions[2].Color)
        {
            case LamaColor.RED:
                action2.color = redColor;
                break;
            case LamaColor.BLUE:
                action2.color = blueColor;
                break;
            case LamaColor.GREEN:
                action2.color = greenColor;
                break;
            case LamaColor.YELLOW:
                action2.color = yellowColor;
                break;
            default:
                action2.color = Color.black;
                break;
        }
        if (currentActions[2].Value != -1)
        {
            value2.gameObject.SetActive(true);
            value2.text = currentActions[2].Value.ToString();
        }
        else
        {
            value2.gameObject.SetActive(false);
        }
    }
}

public enum ActionType
{
    ADDITION,
    SUBSTRACTION,
    TRANSFER,
    COLOR_SWITCH,
    REROLL,
    EXCHANGE,
}
