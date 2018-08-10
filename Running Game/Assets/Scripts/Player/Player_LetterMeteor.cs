using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LetterMeteor : BasePlayerResponse {

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {

        for(int i = 0; i < spawnerManager.viableLetters.Length; i++)
        {
            if (Input.GetKeyDown(spawnerManager.keycodesOfLetters[i]))
            {
                spawnerManager.letterMeteors.TrimExcess();
                for(int j = 0; j < spawnerManager.letterMeteors.Capacity; j++)
                {
                    if(spawnerManager.letterMeteors[j].GetComponent<LetterMeteor>().letter == spawnerManager.viableLetters[i].ToUpper())
                    {
                        
                    }
                }
            }
        }

    }


}
