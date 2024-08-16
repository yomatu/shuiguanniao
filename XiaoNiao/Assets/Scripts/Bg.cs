using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour
{
    public float speed = -2;
    //public float bg_width = 10;
    public SpriteRenderer sprite;
    public float bg_width;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        bg_width = sprite.bounds.size.x-0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;

        if (this.gameObject.transform.position.x<= -bg_width)
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x+2* bg_width,
                this.transform.position.y, this.transform.position.z);
        }
    }
}
