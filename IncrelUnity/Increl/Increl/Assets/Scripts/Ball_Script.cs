using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball_Script : MonoBehaviour
{
    public GameObject Ball; //This object(for static void)
    public static Transform BallTransform; //To change scale in static void
    public float speed; //Speed do ball bigger when touch
    public bool second; //False when ball bigger than target(circle) => player lose
    public bool first; //Trrue when ball smoller than target(circle) => player can win
    public void Start()
    {
        BallTransform = Ball.GetComponent<Transform>();
        //This variable must be with this values
        second = false;
        first = false;
        speed = 0f;
    }
    void Update()
    {
        if(Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Scale());
        }
    }
    public IEnumerator Scale()
    {
        while (second == false && !Input.GetKeyUp(KeyCode.Space) || Input.touchCount > 0 && second == false) //While player not lose
        {
            //Do ball bigger
            speed += 0.00005f;
            transform.localScale = new Vector2(transform.localScale.y + speed, transform.localScale.y + speed);
        }
        //What happened (haw big ball when pleyer stop do it bigger)
        if (Input.GetKeyUp(KeyCode.Space) && first && second || Input.touchCount == 0 && first && second)
        {
            first = false;
            second = false;
            print("midle");

        }
        if (Input.GetKeyUp(KeyCode.Space) && !first && second || Input.touchCount == 0 && !first && second)
        {
            print("win");
            transform.localScale = new Vector2(0, 0);
            second = false;
            first = false;
        }
        if (Input.GetKeyUp(KeyCode.Space) && second || Input.touchCount == 0 && second)
        {
            print("lose");
            second = false;
            first = false;
        }
        yield return new WaitForSeconds(0.001f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //To know haw big ball(to know when player die or won)
        if (collision.gameObject.CompareTag("CircleDiePlase"))
        {
            second = true;
        }
        if (collision.gameObject.CompareTag("CircleWinPlase"))
        {
            first = true;
        }
    }
    public static void Die()
    {
        BallTransform.localScale = new Vector2(0, 0);
    }
}
