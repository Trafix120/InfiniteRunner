using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerResponse : MonoBehaviour {
    public SpawnerManager spawnerManager;
    

	// Use this for initialization
	protected virtual void Start () {
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawnerManager = spawner.GetComponent<SpawnerManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
