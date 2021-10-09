using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => instance;

    [SerializeField] private PaddockManager paddockManager1;
    [SerializeField] private PaddockManager paddockManager2;
    [SerializeField] private int scoreToWin;
    [SerializeField] private GameObject p1Pinata;
    [SerializeField] private GameObject p2Pinata;
    private int p1Score;
    private int p2Score;
    private static GameManager instance;



    public void IncreaseP1Score(int value)
    {
        p1Score += value;
        if (p1Score >= scoreToWin)
        {
            WinGame(p1Pinata);
        }
    }

    public void IncreaseP2Score(int value)
    {
        p2Score += value;
        if (p2Score >= scoreToWin)
        {
            WinGame(p2Pinata);
        }
    }



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitPaddock(paddockManager1);
        InitPaddock(paddockManager2);
    }

    private void InitPaddock(PaddockManager paddockManager)
    {

    }

    private void WinGame(GameObject pinata)
    {

    }
}
