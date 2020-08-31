using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float F_X; //X transform position for all object for game(ball, circles, Touch)
    public static float F_Y; //Y transform position for all object for game(ball, circles, Touch)
    private void Update()
    {
        F_X = transform.position.x;
        F_Y = transform.position.y;

    }
    private void Start()
    {
        F_X = transform.position.x;
        F_Y = transform.position.y;
    }
}
