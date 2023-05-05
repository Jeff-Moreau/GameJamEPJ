using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawner : MonoBehaviour
{
    [SerializeField] GameObjects obsticles;
    // Start is called before the first frame update
    void Start()
    {
        ItemRandomSpawn(Random.Range(0, 30));
    }

    public void ItemRandomSpawn(int numCheck)
    {
        if (numCheck <= 3)
        {
            Instantiate(obsticles.itemObsticle[Random.Range(0, obsticles.itemObsticle.Length)], transform.position, transform.rotation);
        }
        else if (numCheck == 6)
        {
            Instantiate(obsticles.itemObsticle[Random.Range(0, obsticles.itemObsticle.Length)], transform.position, transform.rotation);
        }
        else if (numCheck > 6)
        {

        }
    }
}
