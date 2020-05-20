using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFlyGuns : MonoBehaviour
{
    public string moveSide;
    private float tilt = 20f;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * tilt);
        if (moveSide == "left")
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * tilt);
        }
        else
        {
            transform.Rotate(-(Vector3.forward) * Time.deltaTime * tilt);
        }
        transform.Rotate(Vector3.right * Time.deltaTime * tilt);
    }
}
