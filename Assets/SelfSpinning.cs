using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSpinning : MonoBehaviour
{
    public float dayLength;

    float rotationSpeed = 10f;


    void Update()
    {
        transform.Rotate(-transform.up * rotationSpeed * Time.deltaTime / dayLength, Space.World);
    }
}
