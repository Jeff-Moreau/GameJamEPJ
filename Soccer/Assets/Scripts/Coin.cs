using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 rotationDirection;

    private void Start()
    {

    }
    private void Update()
    {
        transform.Rotate(rotationSpeed * rotationDirection * Time.deltaTime);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
