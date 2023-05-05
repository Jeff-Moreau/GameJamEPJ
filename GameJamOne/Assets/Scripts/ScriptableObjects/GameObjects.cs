using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Objects", fileName = "GameObjects")]
public class GameObjects : ScriptableObject
{
    [SerializeField] public GameObject itemCoin;
    [SerializeField] public GameObject itemHealth;
    [SerializeField] public GameObject[] itemObsticle;
}
