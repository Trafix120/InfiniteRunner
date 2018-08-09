using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour {
    public float range = 1f;
    public float frequency = 1f;
    public float timeTillSpawn;
    public bool showGizmos;
    public Transform spawnedObject;
    public Transform fol;

    protected virtual void Start()
    {
        timeTillSpawn = frequency;
    }

    protected virtual void Spawn()
    {
        timeTillSpawn += Time.deltaTime;
        if (timeTillSpawn > frequency)
        {
            timeTillSpawn = 0;
            Instantiate(spawnedObject, transform.position + Vector3.up * Random.Range(-range, range), Quaternion.identity, fol);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (showGizmos)
        {
            Gizmos.DrawLine(transform.position + Vector3.down * range, transform.position + Vector3.up * range);
        }
    }
}
