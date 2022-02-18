using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    public GameObject Pipes;
    public float SpawnTime = 0f, SpawnAgain = 1.25f;
    private Transform ObjectTransform;
    public float StopTime = 3f;


    public BirdMov BirdScript;

    private void Start()
    {
        ObjectTransform = this.gameObject.transform;
        InvokeRepeating("Spawn", SpawnTime, SpawnAgain);
    }

    private void FixedUpdate()
    {
        if (BirdScript.GhostMode)
        {
            StopTime -= Time.deltaTime;

            if (StopTime<0)
            {
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(2.5f, 0f));
                StopTime = 3f;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().MovePosition(new Vector2(1.5f, 0f));
        }
        
    }

    public void Spawn()
    {


        Instantiate(Pipes, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);
        if (BirdScript.isdead)
        {
            CancelInvoke("Spawn");
        }
    }

}

