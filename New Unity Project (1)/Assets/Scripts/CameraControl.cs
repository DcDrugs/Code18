using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    public float speed, angle;

    public Vector3 offSet;

    void Start()
    {
        angle = transform.eulerAngles.x;
        Time.timeScale = 1f;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                                        player.transform.position - offSet, speed);
        angle -= 3;
        angle = Mathf.Clamp(angle, 40, 90);
        Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.right);
        transform.rotation = quaternion;
    }
}
