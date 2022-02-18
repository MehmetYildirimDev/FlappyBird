using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardBoxSpawner : MonoBehaviour
{
    public GameObject AwardBox;
    public float SpawnTime = 10f, SpawnAgain = 15f;

    public BirdMov BirdScript;

    private void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnAgain);
    }
    public void Spawn()
    {
        Instantiate(AwardBox, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);//spawnlýyor
        if (BirdScript.isdead)
        {
            CancelInvoke("Spawn");
        }
    }
}
