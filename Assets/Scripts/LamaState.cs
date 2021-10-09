using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamaState : MonoBehaviour
{
    public LamaColor Color
    {
        get => color;
        set
        {
            color = value;
            switch (color)
            {
                case LamaColor.BLUE:
                    meshRenderer.material = blueMat;
                    break;
                case LamaColor.RED:
                    meshRenderer.material = redMat;
                    break;
                case LamaColor.GREEN:
                    meshRenderer.material = greenMat;
                    break;
                case LamaColor.YELLOW:
                    meshRenderer.material = yellowMat;
                    break;
            }
        }
    }

    [SerializeField] private Material redMat;
    [SerializeField] private Material blueMat;
    [SerializeField] private Material greenMat;
    [SerializeField] private Material yellowMat;
    private LamaColor color;
    private MeshRenderer meshRenderer;



    public void Init(LamaColor color)
    {
        Color = color;
    }



    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
}

public enum LamaColor
{
    NONE,
    RED,
    YELLOW,
    GREEN,
    BLUE
}
