using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDestroyer : MonoBehaviour {

    private void Update()
    {
        if(transform.position.x < -13)
        {
            Destroy(gameObject);
        }
    }


}
