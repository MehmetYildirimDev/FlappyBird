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

    public float velocity = 1.75f;
    private Rigidbody2D Rb2D;

    [Header("Ghost Mode")]
    public bool GhostMode = false;
    public GameObject Pipes;
    private GameObject[] Dead;
    public float GmCounter=5f;
    public Text CounterText;



    private void Start()
    {
        DefultModeF();

        Rb2D = this.gameObject.GetComponent<Rigidbody2D>();//Bu oyun objesinin rb ula� diyoruz;
        Rb2D.gravityScale = 0.2f;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ku�u S��rat
            if (Rb2D.gravityScale != 1)
            {
                Rb2D.gravityScale = 1;
            }
            GetComponent<AudioSource>().PlayOneShot(jump, 1f);
            Rb2D.velocity = Vector2.up * velocity;
        }


        if (GhostMode)
        {

            Dead = GameObject.FindGameObjectsWithTag("DeadArea");//DeadArea tagli objeleri dead dizisine att�m  
            foreach (GameObject gameObject in Dead)
            {
                gameObject.tag = "Score1";//t�m objelerin tag� score1(tekrar d�nderebilelim diye) yapt�k 
                gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
            GmCounter -= Time.deltaTime;
            CounterText.text = GmCounter.ToString("0.0");
            if (GmCounter<0)
            {
                DefultModeF();
            }
            //Pipes.GetComponent<PipeMov>().Speed = 2f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("DeadArea") || collision.gameObject.tag.Equals("Platform") && !GhostMode)//Ghost modda �lmemesinin sebebi buraya giremiyor
        {
            DeadScene();
        }

        if (collision.gameObject.tag.Equals("Platform"))
        {
            DeadScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Score") || collision.gameObject.tag.Equals("Score1"))
        {
            ManagerGame.UpdateScore();
            GetComponent<AudioSource>().PlayOneShot(point, 1f);
        }
        if (collision.gameObject.tag.Equals("Ghost"))
        {
            GhostModeF();
        }
    }



    private void GhostModeF()
    {
        GhostMode = true;

        GetComponent<Animator>().enabled = false;//animasyon durdu 
        GetComponent<SpriteRenderer>().sprite = BirdSprites[1];//Ghost
        Pipes.GetComponent<PipeMov>().Speed = 2f;
        CounterText.gameObject.SetActive(true);
       
    }
    private void DefultModeF()
    {
        GhostMode = false;
        
        GetComponent<Animator>().enabled = true;//animasyon ba�lad� 
        GetComponent<SpriteRenderer>().sprite = BirdSprites[0];//Bird
        Pipes.GetComponent<PipeMov>().Speed = .5f;
        CounterText.gameObject.SetActive(false);

        Dead = GameObject.FindGameObjectsWithTag("Score1");//DeadArea tagli objeleri dead dizisine att�m  
        foreach (GameObject gameObject in Dead)
        {
            gameObject.tag = "DeadArea";//t�m objelerin tag� score1(tekrar d�nderebilelim diye) yapt�k 
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }
    private void DeadScene()
    {
        Pipes.GetComponent<PipeMov>().Speed = .5f;
        isdead = true;
        GetComponent<AudioSource>().PlayOneShot(die, 1f);
        Time.timeScale = 0;//Oyunu Direk donduruyor ///Sahneyi yeniden y�klerken d�zeltilmesi gerek(1 yap�lmas� )
        Restart.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(true);

    }

}
