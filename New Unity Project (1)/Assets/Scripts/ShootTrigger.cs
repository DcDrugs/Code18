using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : MonoBehaviour
{
    public ObjectShoot obj;

    public string tagNameFight;

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagNameFight))
        {
            obj.target.Add(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagNameFight))
        {
            if (obj.target.Count != 0)
                obj.target.Remove(other.gameObject.transform);

            if (obj.transform.Find("Gun") != null)
                obj.transform.Find("Gun").localRotation = Quaternion.identity;
        }
    }
}
