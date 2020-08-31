using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public Camera C_Camera;
    private void Awake()
    {
        C_Camera = GetComponent<Camera>();
    }
    void Start()
    {
        C_Camera.orthographicSize = Screen.height / 256;
    }
}
