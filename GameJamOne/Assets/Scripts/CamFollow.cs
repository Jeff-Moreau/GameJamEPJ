using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private float yLock;
    // Start is called before the first frame update
    void Start()
    {
        yLock = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(yLock, transform.position.y, transform.position.z);
    }
}
