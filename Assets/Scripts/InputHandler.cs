using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private ActionsManager p1ActionsManager;
    [SerializeField] private ActionsManager p2ActionsManager;



    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            p1ActionsManager.PressKey();
        }
        if (Input.GetKey(KeyCode.Return))
        {
            p2ActionsManager.PressKey();
        }
    }
}
