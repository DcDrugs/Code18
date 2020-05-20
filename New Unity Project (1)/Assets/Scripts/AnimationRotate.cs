using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRotate : MonoBehaviour
{
    public float tilt;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * tilt);
    }
}
