using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMov : MonoBehaviour
{

    public float Speed = .75f;

    private void Start()
    {
        Destroy(this.gameObject, 10);
    }


    private void FixedUpdate()
    {
        this.gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
    }
}
