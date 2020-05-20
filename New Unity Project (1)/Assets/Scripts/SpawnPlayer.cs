using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public float speed;

    public GameObject spawnObj;

    public Transform position;

    public string positionName;


    public void SpawnFunction()
    {
        enabled = true;
        spawnObj = GameObject.Instantiate(spawnObj, position.position + new Vector3(0, 90f, 0), 
                                                                                Quaternion.identity) as GameObject;
        spawnObj.transform.Find("DamageObject").GetComponent<GetDamage>().player = gameObject.GetComponent<RemovePlayer>();

        spawnObj.transform.SetParent(position);

        spawnObj.transform.LookAt(spawnObj.transform.parent.parent.transform);

        spawnObj.transform.localRotation *= Quaternion.AngleAxis(
                                   -90, Vector3.right);

        spawnObj.GetComponent<HealthBarUnit>().position = positionName;
    }

    void Update()
    {
        spawnObj.transform.localPosition = Vector3.MoveTowards(spawnObj.transform.localPosition,
                                                                Vector3.zero, Time.deltaTime * speed);
        if (spawnObj.transform.localPosition == Vector3.zero)
        {
            Rigidbody temp; 
            if (spawnObj.TryGetComponent<Rigidbody>(out temp))
                temp.useGravity = true;

            spawnObj = null;
            position = null;
            positionName = null;
            enabled = false;
        }
    }
}
