using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 rotationDirection;

    private void Update()
    {
        transform.Rotate(rotationSpeed * rotationDirection * Time.deltaTime);
    }
}
