using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    public int theScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            theScore += 10;
            Destroy(other.gameObject);
        }

        
    }
}
