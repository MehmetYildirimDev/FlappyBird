using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{
    public BirdMov BirdScript;
    public GameObject Pipes;

    private void Start()
    {
        StartCoroutine(SpawnObcejt());
    }
    public IEnumerator SpawnObcejt()//Spawnlama i�lemi
    {
        while (!BirdScript.isdead)
        {
            Instantiate(Pipes, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);//spawnl�yor
            yield return new WaitForSeconds(2f);//Bir saniye bekle kodunu yazdik ///bekliyor
        }

    }       
}
