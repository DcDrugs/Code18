using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAnimation : MonoBehaviour
{
    public GameObject obj;

    public GameObject destroyGameObject;

    private int _times = 0;

    void Update()
    {
        if (obj != null)
        {
            obj.SetActive(!obj.activeSelf);
            _times++;
            if (_times >= 5)
            {
                Destroy(destroyGameObject);
            }
        }
    }
}
