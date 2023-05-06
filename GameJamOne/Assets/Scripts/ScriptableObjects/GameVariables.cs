using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Variables", fileName = "GameVariables")]
public class GameVariables : ScriptableObject
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    public int coinsCollected;
    public float playerSpeed;
    public float playerJumpHeight;
    public int goodDecision;
    public int badDecision;


}
