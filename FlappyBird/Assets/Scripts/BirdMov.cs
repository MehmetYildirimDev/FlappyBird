using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdMov : MonoBehaviour
{
    public Sprite[] BirdSprites;
    //     GetComponent<SpriteRenderer>().sprite = BirdSprites[0];//Bird
    //     GetComponent<SpriteRenderer>().sprite = BirdSprites[1];//Ghost
    public AudioClip point, die, jump;

    public Button Restart, MainMenu;
    public GameManager ManagerGame;

    public bool isdead = false;
    public bool GhostMode = false;

    public float velocity = 1.75f;
    private Rigidbody2D Rb2D;

    private void Start()
    {
        Rb2D = this.gameObject.GetComponent<Rigidbody2D>();//Bu oyun objesinin rb ulaþ diyoruz;
        Rb2D.gravityScale = 0.2f;
        Restart.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Kuþu Sýçrat
            if (Rb2D.gravityScale != 1)
            {
                Rb2D.gravityScale = 1;
            }
            GetComponent<AudioSource>().PlayOneShot(jump, 1f);
            Rb2D.velocity = Vector2.up * velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("ScoreArea"))
        {
            ManagerGame.UpdateScore();
            GetComponent<AudioSource>().PlayOneShot(point, 1f);
        }
        if (collision.gameObject.tag.Equals("Ghost"))
        {
            //Debug.Log("Yolunda");
            GhostMode = true;
            GhostModeF();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("DeadArea") && !GhostMode)
        {
            isdead = true;
            GetComponent<AudioSource>().PlayOneShot(die, 1f);
            Time.timeScale = 0;//Oyunu Direk donduruyor ///Sahneyi yeniden yüklerken düzeltilmesi gerek(1 yapýlmasý )
            Restart.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(true);
        }


    }

    private void GhostModeF()
    {
        GetComponent<Animator>().enabled = false;//animasyon durdu 
        GetComponent<SpriteRenderer>().sprite = BirdSprites[1];//Ghost
     //   GetComponent<Collider2D>().enabled = false;///Böyle olursa takip edemeyiz
    }

}
