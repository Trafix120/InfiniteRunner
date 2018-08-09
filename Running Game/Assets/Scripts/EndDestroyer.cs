using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDestroyer : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<LetterMeteor>() == null)
        {
            Destroy(collision.gameObject);
        }
        else
        {
            SpawnerManager spawnerManager = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerManager>();
            spawnerManager.letterMeteors.Remove(collision.transform);
            Destroy(collision.gameObject);
        }

    }


}
