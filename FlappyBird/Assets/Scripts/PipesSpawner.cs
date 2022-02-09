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
   
    public IEnumerator SpawnObcejt()//Spawnlama iþlemi
    {
        while (!BirdScript.isdead && !BirdScript.GhostMode)
        {
            Debug.Log("Spawnernon");
            Instantiate(Pipes, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);//spawnlýyor
            yield return new WaitForSeconds(2f);//Belirli bir saniye bekle kodunu yazdik ///bekliyor
        }
        while (!BirdScript.isdead && BirdScript.GhostMode)
        {
            
            Debug.Log("SpawnerGhost");
            Instantiate(Pipes, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);//spawnlýyor
            yield return new WaitForSeconds(1f);//Belirli bir saniye bekle kodunu yazdik ///bekliyor
        }

    }       
}
