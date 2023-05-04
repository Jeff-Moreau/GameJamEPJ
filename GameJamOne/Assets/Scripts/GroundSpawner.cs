using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject roadTile;
    private int roadTileAmount = 11;
    private int spawnedRoadAmount = 0;
    Vector3 nextSpawnPoint;

    void Start()
    {
        for (int i = 0; i < roadTileAmount; i++)
        {
            SpawnTile();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SpawnTile();
        }
    }


    public void SpawnTile()
    {
        spawnedRoadAmount++;
        if (roadTileAmount == spawnedRoadAmount)
        {
            Instantiate(roadTile, new Vector3(nextSpawnPoint.x, nextSpawnPoint.y, nextSpawnPoint.z + 5), transform.rotation);
            spawnedRoadAmount = 0;
        }
        else
        {
            GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }
    }
}
