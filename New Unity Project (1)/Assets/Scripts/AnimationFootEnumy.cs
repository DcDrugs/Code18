using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFootEnumy : MonoBehaviour
{
    public string moveSide;
    public float tilt;
    void Update()
    {
        if (moveSide == "left")
        {
            transform.Rotate(Vector3.right * Time.deltaTime * tilt);
        }
        else
        {
            transform.Rotate(-(Vector3.right) * Time.deltaTime * tilt);
        }
    }
}