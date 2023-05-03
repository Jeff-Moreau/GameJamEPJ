using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    private Vector3 currentPosition;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * playerSpeed;

        if (Input.GetKeyDown(KeyCode.D)) 
        {
            transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            currentPosition = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
            currentPosition = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            currentPosition = initialPosition;
        }
    }
}
