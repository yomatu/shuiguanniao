using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Ready  = 0,
    Running = 1,
    Pause = 2,
    GameOver= 3,
}


public class GameManager : MonoBehaviour
{
    public GameObject pipelineObj;
    public float pipelinePos_x = 2;
    public float pipelinePos_y = 4;
    public float minRadom_y= -2;
    public float maxRadom_y = 2;


    public float timer = 0;
    public float radomTime = 2;
    public float minRadomTime = 0.5f;
    public float maxRadomTime = 1.5f;

        
    public GameState gameState = GameState.Ready;

    public Button startBtn;
    public Button restartBtn;


    public static GameManager _gameManager;
    public Rigidbody2D birdRigid;
    public float birdGravity=1.5f;


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = this;
        startBtn.gameObject.SetActive(true);

        restartBtn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState!=GameState.Running)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >=  radomTime)
        {
            PipelineBorn();
        }

    }

    void PipelineBorn()
    {

        pipelinePos_y = Random.Range(minRadom_y, maxRadom_y);

        Vector3 piplelinePos = new Vector3(pipelinePos_x, pipelinePos_y, 
            pipelineObj.transform.position.z);

        Instantiate(pipelineObj,piplelinePos,pipelineObj.transform.rotation);

        radomTime = Random.Range(minRadomTime, maxRadomTime);
        timer = 0; 

    }


    public void GameStart()
    {
        gameState = GameState.Running;
        PipelineBorn();

        startBtn.gameObject.SetActive(false);

        if (birdRigid!=null)
        {
            birdRigid.gravityScale = birdGravity;
        }
        startBtn.gameObject.SetActive(false);

        restartBtn.gameObject.SetActive(false);

    }
    public void GameRestart()
    {
        SceneManager.LoadScene("Game");
        GameStart();
        startBtn.gameObject.SetActive(false);

        restartBtn.gameObject.SetActive(false);
    }

}
