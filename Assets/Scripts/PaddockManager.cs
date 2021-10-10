using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PaddockManager : MonoBehaviour
{
    public List<LamaState> Lamas => lamas;

    [SerializeField] private LamaState lamaPrefab;
    [SerializeField] private Collider paddock;
    [SerializeField] private Transform lamasContainer;
    [SerializeField] private PaddockManager otherPaddock;
    [SerializeField] private int initialLamasCount;
    [SerializeField] private int spawningYValue;
    private List<LamaState> lamas;



    public void Add(int count, LamaColor color = LamaColor.NONE)
    {
        AddLamas(count, color);
    }

    public void Add(List<LamaState> lamas)
    {
        this.lamas.AddRange(lamas);
    }

    public void Substract(int count, LamaColor color = LamaColor.NONE)
    {
        RemoveLamas(count, color);
    }

    public void Transfer(int count, LamaColor color = LamaColor.NONE)
    {
        List<LamaState> lamasToTransfer = RemoveLamas(count, color);
        otherPaddock.Add(lamasToTransfer);
        foreach (LamaState lama in lamasToTransfer)
        {
            otherPaddock.SetRandomPosition(lama);
        }
    }

    public void SwitchColors()
    {
        List<LamaColor> colors = System.Enum.GetValues(typeof(LamaColor)).Cast<LamaColor>().ToList();

        List<LamaState> lamasListToSearch = new List<LamaState>();
        lamasListToSearch.AddRange(lamas);
        List<LamaState> lamasInTargetColor = new List<LamaState>();
        for (int i = 0; i < colors.Count; i++)
        {
            LamaColor targetColor = (LamaColor) colors[Random.Range(1, colors.Count)];
            foreach (LamaState lama in lamasInTargetColor)
            {
                lama.Color = targetColor;
                lamasListToSearch.Remove(lama);
            }
            foreach (LamaState lama in lamasListToSearch)
            {
                if (lama.Color == targetColor)
                {
                    lamasInTargetColor.Add(lama);
                }
            }
            colors.Remove(targetColor);
        }
    }

    public void Reroll()
    {
        foreach (LamaState lama in lamas)
        {
            System.Array colors = System.Enum.GetValues(typeof(LamaColor));
            lama.Color = (LamaColor) colors.GetValue(Random.Range(1, colors.Length));
            SetRandomPosition(lama);
        }
    }

    public void Exchange(LamaColor color = LamaColor.NONE)
    {
        List<LamaState> tempList = new List<LamaState>();
        if (color != LamaColor.NONE)
        {
            for (int i = 0; i < lamas.Count; i++)
            {
                if (lamas[i].Color == color)
                {
                    tempList.Add(lamas[i]);
                    lamas.RemoveAt(i);
                }
            }
            for (int i = 0; i < otherPaddock.lamas.Count; i++)
            {
                if (otherPaddock.lamas[i].Color == color)
                {
                    lamas.Add(otherPaddock.lamas[i]);
                    otherPaddock.lamas.RemoveAt(i);
                }
            }
        }
        else
        {
            tempList = lamas;
            lamas = otherPaddock.lamas;
        }
        otherPaddock.lamas = tempList;
        foreach (LamaState lama in lamas)
        {
            SetRandomPosition(lama);
        }
        foreach (LamaState lama in otherPaddock.lamas)
        {
            otherPaddock.SetRandomPosition(lama);
        }
    }

    private void Awake()
    {
        lamas = new List<LamaState>();
    }

    private void Start()
    {
        InitPaddock();
    }

    private void InitPaddock()
    {
        AddLamas(initialLamasCount);
    }

    private void AddLamas(int count, LamaColor color = LamaColor.NONE)
    {
        for (int i = 0; i < count ; i++)
        {
            LamaState lama = Instantiate(lamaPrefab, lamasContainer);
            SetRandomPosition(lama);
            lama.transform.Rotate(Vector3.up * Random.Range(0f, 180f));
            LamaColor actualColor = color;
            if (actualColor == LamaColor.NONE)
            {
                System.Array colors = System.Enum.GetValues(typeof(LamaColor));
                actualColor = (LamaColor) colors.GetValue(Random.Range(1, colors.Length));
            }
            lama.Init(actualColor);
            lamas.Add(lama);
        }
    }

    private List<LamaState> RemoveLamas(int count, LamaColor color = LamaColor.NONE)
    {
        List<LamaState> targetedLamas = new List<LamaState>();
        List<LamaState> removedLamas = new List<LamaState>();
        if (color != LamaColor.NONE)
        {
            foreach (LamaState lama in lamas)
            {
                if (lama.Color == color)
                {
                    targetedLamas.Add(lama);
                }
            }
        }
        else
        {
            targetedLamas = lamas;
        }

        if (count > targetedLamas.Count)
        {
            count = targetedLamas.Count;
        }

        for (int i = 0; i < count; i++)
        {
            LamaState lama = targetedLamas[Random.Range(0, targetedLamas.Count)];
            targetedLamas.Remove(lama);
            lamas.Remove(lama);
            removedLamas.Add(lama);
        }
        return removedLamas;
    }

    private void SetRandomPosition(LamaState lama)
    {
        Vector2 randomLocation2D = ComputeRandomLocation();
        Vector3 randomLocation = new Vector3(randomLocation2D.x, spawningYValue, randomLocation2D.y);
        lama.transform.position = randomLocation;
    }

    private Vector2 ComputeRandomLocation()
    {
        Bounds paddockBounds = paddock.bounds;
        float x = Random.Range(paddockBounds.min.x, paddockBounds.max.x);
        float y = Random.Range(paddockBounds.min.z, paddockBounds.max.z);
        return new Vector2(x, y);
    }
}
