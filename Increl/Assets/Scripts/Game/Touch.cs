using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public GameObject G_PublicTouch;
    public static GameObject G_Touch;
    private bool OnThisPos = false; //When player stop touch ball only on pos when he start touch
    public static bool B_CanTouch = false; //To know WHAT player touch (phone or circle)
    public static string S_Touch = "nope"; //Are player touch ball(d'like to do ball bigger)
    private void Awake()
    {
        G_Touch = G_PublicTouch;
        transform.position = new Vector3(GameController.F_X, GameController.F_Y, transform.position.z);
    }
    public void Start()
    {
        B_CanTouch = false;
    }
    private void Update()
    {
        if (B_CanTouch)
        {
            transform.localScale = new Vector3(
                x: Ball_Controller.G_LevelCircle.transform.localScale.x,
                y: Ball_Controller.G_LevelCircle.transform.localScale.y,
                z: Ball_Controller.G_LevelCircle.transform.localScale.z);
        }
        transform.position = new Vector3(GameController.F_X, GameController.F_Y, transform.position.z);
    }
    private void OnMouseDown() //Player start touch (mouse touch this and when player stop touch doesn't mater)
    {
        S_Touch = "true";
        OnThisPos = true;
    }
    private void OnMouseUp() //Player finish touch (when player stop touch PHONE)
    {
        S_Touch = "false";
        OnThisPos = false;
    }
    private void OnMouseExit() //If player not touch circle (bat touch screen)
    {
        
        if (OnThisPos)
        {
            S_Touch = "exit";
            OnThisPos = false;
        }
    }
}
