using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoockAtCamera : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
