using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMeteor : MonoBehaviour {
    public float speed = 1f;
    public bool move;
    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(player == null)
        {
            Debug.Log("Cannot find player");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
	}
}
