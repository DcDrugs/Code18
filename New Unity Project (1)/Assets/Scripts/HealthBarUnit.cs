using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUnit : MonoBehaviour
{
    public float maxHP;

    public float HP;

    public GameObject healthBar;

    public string position;
    void Start()
    {
        HP = maxHP;
        healthBar = transform.Find("HealthBar").Find("HpBar").gameObject;
    }
}
