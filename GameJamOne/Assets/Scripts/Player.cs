using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpHeight;
    [SerializeField] private Rigidbody playerRiBo;

    private Vector3 currentPosition;
    private Vector3 initialPosition;
    private Vector3 initialScale;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        currentPosition = transform.position;
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * playerSpeed;

        if (Input.GetKeyDown(KeyCode.D) && currentPosition.x < 5) 
        {
            transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            currentPosition = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.A) && currentPosition.x > -5)
        {
            transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
            currentPosition = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            currentPosition = initialPosition;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRiBo.AddRelativeForce(new Vector3(transform.position.x, transform.position.y * playerJumpHeight, transform.position.z));
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y /2, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            currentPosition = transform.position;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }
        
    }
}
