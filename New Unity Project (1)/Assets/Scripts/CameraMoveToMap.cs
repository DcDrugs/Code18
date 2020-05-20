using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveToMap : MonoBehaviour
{
    public float speed, angle;

    private float angleVertical;

    private Vector3 _mapposition = new Vector3(-50, 70, -30);

    void Start()
    {
        angle = transform.eulerAngles.x;
        Time.timeScale = 0.01f;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                         _mapposition, speed);
        angle += 3;
        angle = Mathf.Clamp(angle, 40, 90);
        if (angle == 90)
        {
            transform.Find("MapCanvas").gameObject.SetActive(true);
            transform.Find("GameInterface").gameObject.SetActive(false);
        }
        Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.right);
        transform.rotation = quaternion;
    }
}
