using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => instance;

    [SerializeField] private PaddockManager paddockManager1;
    [SerializeField] private PaddockManager paddockManager2;
    [SerializeField] private int scoreToWin;
    [SerializeField] private GameObject p1Pinata;
    [SerializeField] private GameObject p2Pinata;
    [SerializeField] private ParticleSystem p1Particles;
    [SerializeField] private ParticleSystem p2Particles;
    [SerializeField] private TextMeshProUGUI p1ScoreText;
    [SerializeField] private TextMeshProUGUI p2ScoreText;
    private int p1Score;
    private int p2Score;
    private static GameManager instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip wrongClick;



    public void PlayClick()
    {
        audioSource.PlayOneShot(click);
    }

    public void PlayWrongClick()
    {
        audioSource.PlayOneShot(wrongClick);
    }

    // public void

    public void IncreaseP1Score(int value)
    {
        p1Score += value;
        if (p1Score >= scoreToWin)
        {
            WinGame(p1Pinata);
        }
        p1ScoreText.text = p1Score.ToString();
    }

    public void IncreaseP2Score(int value)
    {
        p2Score += value;
        if (p2Score >= scoreToWin)
        {
            WinGame(p2Pinata);
        }
        p2ScoreText.text = p2Score.ToString();
    }



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitPaddock(paddockManager1);
        InitPaddock(paddockManager2);
        p1ScoreText.text = "0";
        p2ScoreText.text = "0";
    }

    private void InitPaddock(PaddockManager paddockManager)
    {

    }

    private void WinGame(GameObject pinata)
    {
        if (pinata == p1Pinata)
        {
            p1Pinata.SetActive(false);
            p1Particles.Play();
        }
        else if (pinata == p2Pinata)
        {
            p2Pinata.SetActive(false);
            p2Particles.Play();
        }
    }
}
