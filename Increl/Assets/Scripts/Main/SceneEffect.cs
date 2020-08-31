using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEffect : MonoBehaviour
{
    private Vector3 TouchPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0);
        TouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TouchPosition.z = 0;
        transform.position = TouchPosition;
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
