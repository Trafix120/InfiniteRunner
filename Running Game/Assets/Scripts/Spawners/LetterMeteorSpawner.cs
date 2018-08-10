using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMeteorSpawner : BaseSpawner {
    public string[] viableLetters;          // Letters that are on the right side of the keyboard
    public KeyCode[] keyCodes;
    protected override void Start()
    {
        base.Start();
        SetLetter();
    }

    // Update is called once per frame
    void Update () {
        Spawn();
	}

    protected override void Spawn()
    {
        base.Spawn();
        SetLetter();
    }

    private void SetLetter()
    {
        spawnedObject.GetComponentInChildren<TextMesh>().text = viableLetters[Random.Range(0, viableLetters.Length - 1)].ToUpper();
    }
}
