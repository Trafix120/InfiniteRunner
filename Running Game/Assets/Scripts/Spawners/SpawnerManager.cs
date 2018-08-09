using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {
    // This manages when all the scripts are enabled
    private BaseSpawner[] spawnerScripts;
    public SpawnerInfo[] spawnerInfo;
    private float currentTime;

    // Info for the player script to use
    public string[] viableLetters;
    public List<Transform> letterMeteors = new List<Transform>();

	// Use this for initialization
	void Start () {
        spawnerScripts = GetComponents<BaseSpawner>();
        for (int i = 0; i < spawnerScripts.Length; i++)
        {
            if(spawnerScripts != null)
            {
                spawnerInfo[i].spawnerScript = spawnerScripts[i];
            }
        }

        // Initating spawner information
        viableLetters = GetComponent<LetterMeteorSpawner>().viableLetters;
        

	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

		// ||| Enable LetterMeteor |||
        if(currentTime >= spawnerInfo[1].activateTime)
        {
            spawnerScripts[1].enabled = true;
        }
	}

    public void AddMeteorLetter(Transform meteor)
    {
        letterMeteors.Add(meteor);
    }

    [System.Serializable]
    public class SpawnerInfo {
        public float activateTime;
        public BaseSpawner spawnerScript;
    }

    
}
