using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    private BaseSpawner[] spawnerScripts;
    public SpawnerInfo[] spawnerInfo;
    public float currentTime;

	// Use this for initialization
	void Start () {
        spawnerScripts = GetComponents<BaseSpawner>();
        for(int i = 0; i < spawnerScripts.Length; i++)
        {
            if(spawnerScripts != null)
            {
                Debug.Log("Did something");
                spawnerInfo[i].spawnerScript = spawnerScripts[i];
            }
        }
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

    [System.Serializable]
    public class SpawnerInfo {
        public float activateTime;
        public BaseSpawner spawnerScript;
    }

    
}
