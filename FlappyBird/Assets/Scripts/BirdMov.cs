using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMov : MonoBehaviour
{
    public GameManager ManagerGame;

    public bool isdead = false; 

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("ScoreArea"))
        {
            ManagerGame.UpdateScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("DeadArea"))
        {
            isdead = true;
            Time.timeScale=0;//Oyunu Direk donduruyor ///Sahneyi yeniden y�klerken d�zeltilmesi gerek(1 yap�lmas� )
        }
    }
}
