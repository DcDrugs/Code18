using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Vector3 nextPosition;
    private Vector3 _lastPosition;
    private Vector3 _target;

    void Start()
    {
        _lastPosition = transform.position;
        _target = _lastPosition;

    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * speed);
        if (transform.position == nextPosition)
            _target = _lastPosition;
        else if (transform.position == _lastPosition)
            _target = nextPosition;
    }
}
