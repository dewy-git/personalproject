using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 10;
    private float lowerBound = -10;
    public float gameObject.tag Obstacle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy gameObject.tag Obstacle;
        } else if (transform.position.z < lowerBound)
        {
            Destroy gameObject.tag Obstacle;
        }
    }
}
