using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float timeSpawn = 2f;
    private float timer;

    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = timeSpawn;
            Instantiate(prefab, transform.position, prefab.transform.rotation);
        }
    }
}
