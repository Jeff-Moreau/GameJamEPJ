using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpHeight;
    [SerializeField] private Rigidbody playerRiBo;

    private float resetTimer;
    private Vector3 currentPosition;
    private Vector3 initialPosition;
    private Vector3 initialScale;
    private float initialSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = playerSpeed;
        initialPosition = transform.position;
        currentPosition = transform.position;
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        resetTimer += Time.deltaTime;
        Debug.Log(resetTimer);
        transform.position += transform.forward * Time.deltaTime * playerSpeed;
        MovementInput();
        CountDownStart();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerSpeed = 0;
        transform.position = initialPosition;
        ResetTimer();
    }
    private void MovementInput()
    {
        if (Input.GetKeyDown(KeyCode.D) && currentPosition.x < 4)
        {
            transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            currentPosition = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.A) && currentPosition.x > -4)
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
            playerRiBo.AddForce(new Vector3(transform.position.x, transform.position.y * playerJumpHeight, transform.position.z));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRiBo.AddForce(new Vector3(transform.position.x, transform.position.y * (-playerJumpHeight / 3), transform.position.z));
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            currentPosition = transform.position;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }
    }

    private void ResetTimer()
    {
        resetTimer = 0;
        Debug.Log("Time was Reset to 0");
    }

    private void CountDownStart()
    {
        if (resetTimer > 3 && transform.position == initialPosition)
        {
            Debug.Log("Should Start Moving Now.");
            playerSpeed = initialSpeed;
            resetTimer = 0;
        }
    }
}
