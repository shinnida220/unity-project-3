using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start position of the attached background
    private Vector3 startPos;

    // Background repeat width
    public float repeatWidth;
    void Start()
    {
        // Save the initial start position of the background
       startPos = transform.position;
       repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Do a check and reset the entire position of the object if it has gone to the left
        if (transform.position.x < startPos.x - repeatWidth) {
            transform.position = startPos;
        }
    }
}
