using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardBoxSpawner : MonoBehaviour
{
    public BirdMov BirdScript;
    public GameObject AwardBox;

    private void Start()
    {
        StartCoroutine(SpawnCircle());
    }
    public IEnumerator SpawnCircle()//Spawnlama i�lemi
    {
        while (!BirdScript.isdead )
        {

            Instantiate(AwardBox, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(6f, 20f));

        }

    }
}
