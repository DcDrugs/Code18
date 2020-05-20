using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFoot : MonoBehaviour
{
    public float tilt;
    public float position;
    private int _side;
    private float _rotateChange;

    void Start()
    {
        _side = 1;
        _rotateChange = 0;
    }
    void Update()
    {
        _rotateChange += _side * tilt;
        transform.Rotate(Vector3.forward * _side * tilt);
        if (Mathf.Abs(_rotateChange - position) < tilt)
        {
            _side = -1;
            _rotateChange = 0;

        }
        else if (Mathf.Abs(_rotateChange + position) < tilt)
        {
            _side = 1;
            _rotateChange = 0;
        }
    }
}
