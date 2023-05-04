using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 rotationDirection;

    GameObject testPlayer;
    float checkZPos;
    private void Start()
    {
        /*testPlayer = gameObject.
        checkZPos = testPlayer.transform.position.z;
        checkZPos += 5;*/
    }
    private void Update()
    {
        transform.Rotate(rotationSpeed * rotationDirection * Time.deltaTime);
        /*if (checkZPos > transform.position.z)
        {
            Destroy(gameObject);
        }*/
    }

    
}
