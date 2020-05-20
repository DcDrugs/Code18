using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroMove : MonoBehaviour
{
    public Transform target;

    public GameObject emty;

    void Start()
    {

    }

    void Update()
    {
        if (target != null)
        {
            GameObject b = GameObject.Instantiate(emty, target.position, Quaternion.identity) as GameObject;
            b.GetComponent<BulletMove>().target = target;
            b.GetComponent<BulletMove>().bullet = b;
            b.transform.SetParent(transform);
        }
        transform.LookAt(target);
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
