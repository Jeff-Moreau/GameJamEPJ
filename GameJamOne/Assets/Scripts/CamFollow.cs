using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private float yLock;
    // Start is called before the first frame update
    void Start()
    {
        yLock = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, yLock, transform.position.z);
    }
}
