using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public Vector2 bird_Veloicity = new Vector2(0,5);
    public Sprite[] birdSprites;
    public float timer = 0;
    public int speed = 10;

    public AudioSource fly;
    public AudioSource cross;
    public AudioSource hit;


    public float Score = 0;

    public Text scoreText;





    // Start is called before the first frame update
    void Start()
    {
         if(scoreText!=null)
        {
            scoreText.text=Score.ToString();
        }

         this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._gameManager.gameState != GameState.Running)
        {
            return;
        }


        timer += Time.deltaTime*speed;
        int index =(int) timer % 2;

        this.GetComponent<SpriteRenderer>().sprite = birdSprites[index];



        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody2D rigid = this.gameObject.GetComponent<Rigidbody2D>();

            if (rigid != null)
            {
                rigid.velocity = bird_Veloicity;

                if (fly!=null)
                {
                    fly.Play(); 
                }
            }

        }
    }

    //dead
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (hit != null)
        {
            hit.Play();
        }
        GameManager._gameManager.gameState = GameState.GameOver;
        this.GetComponent<SpriteRenderer>().sprite = birdSprites[2];
     

        GameManager._gameManager.restartBtn.gameObject.SetActive(true );

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ScorePipeline"))
        {

            Score += 1;

            if (scoreText !=null)
            {
                scoreText.text = Score.ToString();
            }
            if (cross!=null)
            {
                cross.Play(); 
            }
        }
        

    }


}
