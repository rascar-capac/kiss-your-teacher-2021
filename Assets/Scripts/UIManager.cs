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
        action0.text = currentActions[0].Value.ToString();
        action1.text = currentActions[1].Value.ToString();
        action2.text = currentActions[2].Value.ToString();
    }

    public void UpdateTasks(Task[] currentTasks)
    {
        task0.text = currentTasks[0].Value.ToString();
        task1.text = currentTasks[1].Value.ToString();
        task2.text = currentTasks[2].Value.ToString();
    }
}
