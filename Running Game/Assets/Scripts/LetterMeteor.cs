using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMeteor : MonoBehaviour {
    public float speed = 1f;
    public bool move;
    private Vector3 player;
    private Vector3 direction;
    private SpawnerManager spawner;
    public string letter;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        direction = (player - transform.position).normalized;
        spawner = GameObject.FindGameObjectWithTag("Spawner").transform.GetComponent<SpawnerManager>();
        letter = GetComponentInChildren<TextMesh>().text;
        spawner.AddMeteorLetter(transform);
        if (player == null)
        {
            Debug.Log("Cannot find player");
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        if (move)
        {
            transform.position += direction * speed;
        }
	}
}
