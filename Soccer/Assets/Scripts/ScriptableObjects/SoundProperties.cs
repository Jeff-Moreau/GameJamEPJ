using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound Properties", fileName = "SoundProperties")]
public class SoundProperties : ScriptableObject
{
    public AudioClip audioMainMusic;
    public AudioClip audioPlayerMove;
    public AudioClip audioGameCount;
    public AudioClip audioCoin;
    public AudioClip audioHit;
    public AudioClip audioHealth;
    public float gameCountDelay;
}
