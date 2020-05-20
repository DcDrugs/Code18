using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    public string bulletInfo;

    public int priceForDestroyingTheTower;

    public RemovePlayer player;

    private Text _money;

    private HealthBarUnit _healthBarUnit;

    void Start()
    {
        _healthBarUnit = transform.parent.GetComponent<HealthBarUnit>();
        _money = GameObject.FindGameObjectWithTag("MainCamera").transform.Find("GameInterface").Find("Money").GetComponent<Text>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bulletInfo))
        {
            float damage = 0;
            damage = other.gameObject.GetComponent<BulletMove>().damage;

            Destroy(other.gameObject);
            _healthBarUnit.HP -= damage;
            if (_healthBarUnit.HP <= 0)
            {
                if (transform.parent.tag == "Enemy")
                {
                    int moneyOnScreen = int.Parse(_money.text);
                    moneyOnScreen += priceForDestroyingTheTower;
                    _money.text = moneyOnScreen.ToString();
                    DieAnimation dieAnimation = transform.parent.parent.gameObject.GetComponent<DieAnimation>();
                    dieAnimation.destroyGameObject = transform.parent.parent.gameObject;
                    dieAnimation.obj = transform.parent.gameObject;
                    dieAnimation.enabled = true;
                }
                if(transform.parent.tag == "FootPlayer" || transform.parent.tag == "FlyPlayer" ||
                                                                    transform.parent.tag == "Player")
                {
                    player.RemovePositionAndPlayer(transform.parent.gameObject);
                }
            }
            else
            {
                float x = damage / _healthBarUnit.maxHP;
                _healthBarUnit.healthBar.transform.localScale -= new Vector3(x, 0, 0);
            }
        }
    }
}
