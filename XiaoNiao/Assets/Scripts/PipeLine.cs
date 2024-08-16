using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PipeLine : MonoBehaviour
{
    public float speed = -2;

    public float x_Limit = 5;



    void Start()
    {

 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._gameManager.gameState!=GameState.Running)
        {
            return;
        }

        this.gameObject.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;

        if (this.transform.position.x <=x_Limit)
        {
            Destroy(this.gameObject);
        }


    }
}
