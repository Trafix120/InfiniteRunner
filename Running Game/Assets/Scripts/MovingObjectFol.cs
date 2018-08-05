using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectFol : MonoBehaviour {
    public float speed = 1f;        // The objects speed
    public bool move = true;        // Whether or not the objects move

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
