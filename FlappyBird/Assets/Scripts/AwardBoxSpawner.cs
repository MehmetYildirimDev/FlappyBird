using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardBoxSpawner : MonoBehaviour
{
    public BirdMov BirdScript;
    public GameObject Circle;

    private void Start()
    {
        StartCoroutine(SpawnCircle());
    }
    public IEnumerator SpawnCircle()//Spawnlama i�lemi
    {
        while (!BirdScript.isdead && !BirdScript.GhostMode)
        {

            Instantiate(Circle, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);//spawnl�yor
            yield return new WaitForSeconds(Random.Range(5f, 15f));//Bir saniye bekle kodunu yazdik ///bekliyor

        }

    }
}