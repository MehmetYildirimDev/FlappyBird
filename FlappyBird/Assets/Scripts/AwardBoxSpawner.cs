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
    public IEnumerator SpawnCircle()//Spawnlama iþlemi
    {
        while (!BirdScript.isdead && !BirdScript.GhostMode)
        {

            Instantiate(AwardBox, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);//spawnlýyor
            yield return new WaitForSeconds(Random.Range(5f, 15f));//Bir saniye bekle kodunu yazdik ///bekliyor

        }

    }
}
