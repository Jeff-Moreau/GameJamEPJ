using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRiBo;
    [SerializeField] private GameObject spawner;
    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] private TextMeshProUGUI totalCoins;
    [SerializeField] private TextMeshProUGUI countTimer;
    [SerializeField] private AudioSource playerSounds;
    [SerializeField] private AudioSource gameSounds;
    [SerializeField] private GameVariables gameVariables;
    [SerializeField] private GameObjects objectsInGame;
    [SerializeField] private SoundProperties soundProperties;

    private int timeMiliSeconds;
    private int timeSeconds;
    private int timeMinutes;
    private bool canJump;
    private bool playerCanMove;
    private float initialSpeed;
    private float startSpeed;
    private float resetTimer;
    private float gameTime;
    private Vector3 currentPosition;
    private Vector3 initialPosition;
    private Vector3 initialScale;


    // Start is called before the first frame update
    void Start()
    {
        playerCanMove = false;
        gameVariables.coinsCollected = 0;
        Debug.Log(objectsInGame.itemObsticle[0].name);
        totalCoins.text = "" + gameVariables.coinsCollected;
        startSpeed = 0;
        initialSpeed = gameVariables.playerSpeed;
        gameVariables.playerSpeed = startSpeed;
        initialPosition = transform.position;
        currentPosition = transform.position;
        initialScale = transform.localScale;
        timeMiliSeconds = 0;
        timeSeconds = 0;
        timeMinutes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        resetTimer += Time.deltaTime;
        //Debug.Log(resetTimer);
        //TheTimer();
        CountDownStart();
        MovementInput();
        if (currentPosition.x > 5)
        {
            currentPosition.x = 5;
            transform.position = currentPosition;
        }
        if (currentPosition.x < -5)
        {
            currentPosition.x = -5;
            transform.position = currentPosition;
        }
        transform.position += transform.forward * Time.deltaTime * gameVariables.playerSpeed;
    }

    private void TheTimer()
    {
        if (gameTime < 1)
        {
            timeMiliSeconds = (int)gameTime;
        }
        if (gameTime >= 1 && gameTime <60)
        {
            timeSeconds = (int)gameTime;
        }
        countTimer.text = "" + timeMinutes + ":" + timeSeconds + ":" + timeMiliSeconds;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obsticle")
        {
            gameVariables.playerSpeed = 0;
            transform.position = initialPosition;
            ResetTimer();
        }
        if (other.gameObject.layer == 3)
        {
            spawner.GetComponent<GroundSpawner>().SpawnTile();
        }
        if (other.gameObject.tag == "Coin")
        {
            gameVariables.coinsCollected++;
            Destroy(other.gameObject);
            totalCoins.text = "" + gameVariables.coinsCollected;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            
            Destroy(other.gameObject, 0.5f);
            
        }
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
        if (playerCanMove == true)
        {
            if (Input.GetKeyDown(KeyCode.D) && currentPosition.x < 4)
            {
                playerSounds.PlayOneShot(soundProperties.audioPlayerMove);
                transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
                currentPosition = transform.position;
            }
            if (Input.GetKeyDown(KeyCode.A) && currentPosition.x > -4)
            {
                playerSounds.PlayOneShot(soundProperties.audioPlayerMove);
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
                playerRiBo.AddForce(new Vector3(transform.position.x, transform.position.y * gameVariables.playerJumpHeight, transform.position.z));
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                playerRiBo.AddForce(new Vector3(transform.position.x, transform.position.y * (-gameVariables.playerJumpHeight / 3), transform.position.z));
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerSounds.PlayOneShot(soundProperties.audioPlayerMove);
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
            if (!gameSounds.isPlaying)
            {
                gameSounds.clip = soundProperties.audioGameCount;
                gameSounds.PlayDelayed(soundProperties.gameCountDelay*Time.deltaTime);
            }
        }
        else if (resetTimer >1 && resetTimer <= 2 && transform.position == initialPosition)
        {
            countDownText.text = "2";
            if (!gameSounds.isPlaying)
            {
                gameSounds.clip = soundProperties.audioGameCount;
                gameSounds.PlayDelayed(soundProperties.gameCountDelay * Time.deltaTime);
            }
        }
        else if (resetTimer >2 && resetTimer <= 3 && transform.position == initialPosition)
        {
            countDownText.text = "1";
            if (!gameSounds.isPlaying)
            {
                gameSounds.clip = soundProperties.audioGameCount;
                gameSounds.PlayDelayed(soundProperties.gameCountDelay * Time.deltaTime);
            }
        }
        else if (resetTimer > 3 && transform.position == initialPosition)
        {
            countDownText.text = "GO";
            if (!gameSounds.isPlaying)
            {
                gameSounds.clip = soundProperties.audioGameCount;
                gameSounds.PlayDelayed(soundProperties.gameCountDelay * Time.deltaTime);
            }
            //Debug.Log("Should Start Moving Now.");
            gameVariables.playerSpeed = initialSpeed;
            playerCanMove = true;
        }
        else if (resetTimer > 4)
        {
            resetTimer = 0;
            countDownText.text = "";
        }
    }
}
