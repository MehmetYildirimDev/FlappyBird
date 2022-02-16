using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    public GameObject Pipes;
    public float SpawnTime=0f, SpawnAgain=1.25f;

    public BirdMov BirdScript;

    private void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnAgain);
    }
    public void Spawn() {
        Instantiate(Pipes, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);//spawnlýyor
        if (BirdScript.isdead)
        {
            CancelInvoke("Spawn");
        }
    }

}

