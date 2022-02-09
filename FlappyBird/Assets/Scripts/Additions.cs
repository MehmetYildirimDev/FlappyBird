using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Additions : MonoBehaviour
{
    public BirdMov BirdScript;
    public GameObject GhostBox;

    public float Speed = 1f;

    private void Start()
    {
        StartCoroutine(SpawnGhost());
        
    }
  

    public IEnumerator SpawnGhost()//Spawnlama iþlemi
    {
        while (!BirdScript.isdead)
        {
            Instantiate(GhostBox, new Vector3(1.5f, Random.Range(-0.4f, 0.4f), 1f), Quaternion.identity);//spawnlýyor
            yield return new WaitForSeconds(1f);//Bir saniye bekle kodunu yazdik ///bekliyor
        }
    }


}
