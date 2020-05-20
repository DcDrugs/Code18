using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLookAtObj : MonoBehaviour
{
    private Transform _target;

    void Start()
    {
        _target = transform.parent.parent.transform;
    }
    void FixedUpdate()
    {
        transform.localRotation = _target.rotation * Quaternion.AngleAxis(90, Vector3.up);
        enabled = false;
    }
}
