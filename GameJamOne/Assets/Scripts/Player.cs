using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioSource sourceCounter;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioClip counter;
    [SerializeField] float playerSpeed;
    [SerializeField] float playerJumpHeight;
    [SerializeField] Rigidbody playerRiBo;
    [SerializeField] TextMeshProUGUI countDownText = null;

    private float audioDelayed;
    private bool canJump;
    private float initialSpeed;
    private float startSpeed;
    private float resetTimer;

    private Vector3 currentPosition;
    private Vector3 initialPosition;
    private Vector3 initialScale;


    // Start is called before the first frame update
    void Start()
    {
        audioDelayed = 18f;
        sourceCounter = GetComponent<AudioSource>();
        sourceCounter.clip = counter;
        startSpeed = 0;
        initialSpeed = playerSpeed;
        playerSpeed = startSpeed;
        initialPosition = transform.position;
        currentPosition = transform.position;
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        resetTimer += Time.deltaTime;
        //Debug.Log(resetTimer);
        transform.position += transform.forward * Time.deltaTime * playerSpeed;
        CountDownStart();
        MovementInput();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerSpeed = 0;
        transform.position = initialPosition;
        ResetTimer();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    private void MovementInput()
    {
        if (Input.GetKeyDown(KeyCode.D) && currentPosition.x < 4)
        {
            source.PlayOneShot(clip);
            transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            currentPosition = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.A) && currentPosition.x > -4)
        {
            source.PlayOneShot(clip);
            transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
            currentPosition = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            currentPosition = initialPosition;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRiBo.AddForce(new Vector3(transform.position.x, transform.position.y * playerJumpHeight, transform.position.z));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRiBo.AddForce(new Vector3(transform.position.x, transform.position.y * (-playerJumpHeight / 3), transform.position.z));
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            source.PlayOneShot(clip);
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
        if (resetTimer <=1 && transform.position == initialPosition)
        { 
            countDownText.text = "3";
            if (!sourceCounter.isPlaying)
            {
                sourceCounter.clip = counter;
                sourceCounter.PlayDelayed(audioDelayed*Time.deltaTime);
            }
        }
        else if (resetTimer >1 && resetTimer <= 2 && transform.position == initialPosition)
        {
            countDownText.text = "2";
            if (!sourceCounter.isPlaying)
            {
                sourceCounter.clip = counter;
                sourceCounter.PlayDelayed(audioDelayed * Time.deltaTime);
            }
        }
        else if (resetTimer >2 && resetTimer <= 3 && transform.position == initialPosition)
        {
            countDownText.text = "1";
            if (!sourceCounter.isPlaying)
            {
                sourceCounter.clip = counter;
                sourceCounter.PlayDelayed(audioDelayed * Time.deltaTime);
            }
        }
        else if (resetTimer > 3 && transform.position == initialPosition)
        {
            countDownText.text = "GO";
            if (!sourceCounter.isPlaying)
            {
                sourceCounter.clip = counter;
                sourceCounter.PlayDelayed(audioDelayed * Time.deltaTime);
            }
            Debug.Log("Should Start Moving Now.");
            playerSpeed = initialSpeed;      
        }
        else if (resetTimer > 4)
        {
            resetTimer = 0;
            countDownText.text = "";
        }
    }
}
