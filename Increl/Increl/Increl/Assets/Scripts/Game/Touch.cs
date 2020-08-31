using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public static string S_Touch; //Are player touch ball(d'like to do ball bigger)
    void Start()
    {
        transform.position = new Vector3(GameController.F_X, GameController.F_Y, transform.position.z);
        S_Touch = "nope";
    }
    public void OnMouseDown() //Player start touch
    {
        S_Touch = "true";
    }
    public void OnMouseUp() //Player finish touch
    {
        S_Touch = "false";
    }
    public void Update()
    {
        if (Ball_Controller.level >= 30)
        {
            transform.position = new Vector3(0, 0, transform.position.z);
        }
        transform.position = new Vector3(GameController.F_X, GameController.F_Y, transform.position.z);
    }
}
