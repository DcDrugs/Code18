using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationElectroGuns : MonoBehaviour
{
    public float speed;
    public Vector3  nextPosition;
    private Vector3 _lastPosition;
    private Vector3 _target;

    void Start()
    {
        _lastPosition = transform.localPosition;
        _target = _lastPosition;

    }
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, _target, Time.deltaTime * speed);
        if (transform.localPosition == nextPosition)
            _target = _lastPosition;
        else if (transform.localPosition == _lastPosition)
            _target = nextPosition;
    }
}
