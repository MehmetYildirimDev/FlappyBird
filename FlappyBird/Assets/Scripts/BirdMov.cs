using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdMov : MonoBehaviour
{
    public Button Restart, MainMenu;
    public GameManager ManagerGame;

    public bool isdead = false; 

    public float velocity = 0.7f;
    private Rigidbody2D Rb2D;

    private void Start()
    {
        Rb2D = this.gameObject.GetComponent<Rigidbody2D>();//Bu oyun objesinin rb ula� diyoruz;
        Rb2D.gravityScale = 0.2f;
        Restart.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ku�u S��rat
            Rb2D.gravityScale = 1;
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
            Restart.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(true);
        }
    }
}
