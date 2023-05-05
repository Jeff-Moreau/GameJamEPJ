using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Variables", fileName = "GameVariables")]
public class GameVariables : ScriptableObject
{
    public int playerHealth;
    public int coinsCollected;
    public float playerSpeed;
    public float playerJumpHeight;
    
}