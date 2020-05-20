using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ObjectShoot : MonoBehaviour
{
    public GameObject bullet;

    public Transform LookAtObj;

    public List<Transform> target = new List<Transform>();

    public Transform shootPosition;
        
    public float shootDelay;

    public bool isObjectElectro;

    private bool isShoot = false;
    void Start()
    {

    }


    void Update()
    {
        if (target.Count != 0)
        {
            if (target[0] == null)
            {
                target.RemoveAt(0);
                return;
            }

            LookAtObj.transform.LookAt(target[0]);
            if (isShoot == false)
            {
                StartCoroutine(shoot());
            }
        }
    }

    IEnumerator shoot()
    {
        isShoot = true;
        GameObject b = GameObject.Instantiate(bullet, shootPosition.position, Quaternion.identity) as GameObject;
        b.transform.SetParent(transform);
        if (isObjectElectro == false)
        {
            b.GetComponent<BulletMove>().target = target[0];
            b.GetComponent<BulletMove>().bullet = b;
        }
        else
        {
            b.GetComponent<ElectroMove>().target = target[0];
            yield return new WaitForSeconds(5);
            Destroy(b);
        }
        yield return new WaitForSeconds(shootDelay);
        isShoot = false;
    }
}
