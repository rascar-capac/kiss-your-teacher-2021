using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationPeriod;



    private void Update()
    {
        transform.Rotate(Vector3.forward, -(360 / rotationPeriod) * Time.deltaTime);
    }
}
