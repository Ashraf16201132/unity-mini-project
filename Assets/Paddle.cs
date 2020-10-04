using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{  
    float speed;
    float height;

    string input;
   public bool isRight;

    // use this for initialization
    void Start()
    {
        height = transform.localScale.y;
        speed = 5f;
    }

    public void Init(bool isRightPaddle ){
        isRight = isRightPaddle;
        vector2 pos = vector2.zero;
        if (isRightPaddle){
            // place paddle on the right of the screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; // move a bit to the left
             
             input = "PaddleRight";

        } else {
            // place paddle on the left of the screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
             pos += Vector2.right * transform.localScale.x; // move a bit to the right

             input = "PaddleLeft";
        }
         
         // update this paddle's positon
        transform.position = pos;

        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        // now lets move the paddle
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        // Restrict paddle movement 
        // if paddle is too low and user is continuing to move down,stop
        if (transform.positon.y < GameManager.bottomLeft.y+ height / 2 && move < o) {
            move = 0;
        }
         // if paddle is too high and user is continuing to move up,stop
        if (transform.positon.y > GameManager.TopRight.y - height / 2 && move > o) {
            move = 0;
        }

        transform.Translate (move * Vector2.up);
    }
}
