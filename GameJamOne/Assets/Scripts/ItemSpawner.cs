using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject itemCoin;
    [SerializeField] GameObject itemHealth;
    // Start is called before the first frame update
    void Start()
    {
        ItemRandomSpawn(Random.Range(0,20));
    }

    public void ItemRandomSpawn(int numCheck)
    {
        if(numCheck <= 5)
        {
            Instantiate(itemCoin, transform.position, transform.rotation);
        }
        else if (numCheck >5 && numCheck <= 7)
        {
            Instantiate(itemHealth, transform.position, transform.rotation);
        }
        else if (numCheck >=7)
        {

        }

    }
}
