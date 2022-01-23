using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMov : MonoBehaviour
{
    public float velocity = 1f;
    private Rigidbody2D Rb2D;

    private void Start()
    {
        Rb2D = this.gameObject.GetComponent<Rigidbody2D>();//Bu oyun objesinin rb ula� diyoruz;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ku�u S��rat
            Rb2D.velocity = Vector2.up * velocity;
        }
    }
}
