using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObjects obstacles;
    // Start is called before the first frame update
    void Start()
    {
        ItemRandomSpawn(Random.Range(0, 30));
    }

    public void ItemRandomSpawn(int numCheck)
    {
        if (numCheck <= 3)
        {
            Instantiate(obstacles.itemObstacle[0], transform.position, transform.rotation);
        }
        else if (numCheck == 6)
        {
            Instantiate(obstacles.itemObstacle[0], transform.position, transform.rotation);
        }
        else if (numCheck > 6)
        {

        }
    }
}
