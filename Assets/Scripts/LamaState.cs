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
                    bodyRenderer.material = blueMat;
                    eyesRenderer.material = blueMat;
                    earsRenderer.material = blueMat;
                    break;
                case LamaColor.RED:
                    bodyRenderer.material = redMat;
                    eyesRenderer.material = redMat;
                    earsRenderer.material = redMat;
                    break;
                case LamaColor.GREEN:
                    bodyRenderer.material = greenMat;
                    eyesRenderer.material = greenMat;
                    earsRenderer.material = greenMat;
                    break;
                case LamaColor.YELLOW:
                    bodyRenderer.material = yellowMat;
                    eyesRenderer.material = yellowMat;
                    earsRenderer.material = yellowMat;
                    break;
            }
        }
    }

    [SerializeField] private Material redMat;
    [SerializeField] private Material blueMat;
    [SerializeField] private Material greenMat;
    [SerializeField] private Material yellowMat;
    private LamaColor color;
    [SerializeField] private MeshRenderer bodyRenderer;
    [SerializeField] private MeshRenderer eyesRenderer;
    [SerializeField] private MeshRenderer earsRenderer;



    public void Init(LamaColor color)
    {
        Color = color;
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
