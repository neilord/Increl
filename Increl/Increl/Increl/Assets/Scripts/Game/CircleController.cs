using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(GameController.F_X, GameController.F_Y, transform.position.z);
    }
    private void Update()
    {
        transform.position = new Vector3(GameController.F_X, GameController.F_Y, transform.position.z);
    }
}
