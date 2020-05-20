using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyArmy : MonoBehaviour
{
    public GameObject tank;

    public GameObject people;

    public GameObject helicopter;

    private bool isMouseEnter = false;

    private bool isMouseExit = false;

    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = this.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (isMouseEnter)
        {
            MoveBuyThings(new Vector3(0, 12f, 0), new Vector3(0, 7f, 0), new Vector3(0, 4f, 0));
        }
        if (people.transform.localPosition == (new Vector3(0, 12f, 0)))
        {
            _boxCollider.size = new Vector3(5.12f, 17f, 0.2f);
            _boxCollider.center = new Vector3(0, 6f, 0);
            isMouseEnter = false;
        }


        if (isMouseExit)
        {
            MoveBuyThings(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        }
        if (people.transform.localPosition == new Vector3(0, 0, 0))
        {
            _boxCollider.size = new Vector3(5.12f, 5.12f, 0.2f);
            _boxCollider.center = new Vector3(0, 0, 0);
            people.SetActive(false);
            tank.SetActive(false);
            helicopter.SetActive(false);
            isMouseExit = false;
        }
    }

    private void MoveBuyThings(Vector3 peopleTo, Vector3 tankTo, Vector3 helicopterTo)
    {
        people.transform.localPosition = Vector3.MoveTowards(people.transform.localPosition, peopleTo, 5);
        tank.transform.localPosition = Vector3.MoveTowards(tank.transform.localPosition, tankTo, 3);
        helicopter.transform.localPosition = Vector3.MoveTowards(helicopter.transform.localPosition, helicopterTo, 1);
    }

    public void OnMouseExit()
    {
        if (gameObject.name == "Buy")
        {
            isMouseExit = true;
            isMouseEnter = false;
        }
    }

    public void OnMouseEnter()
    {
        if (gameObject.name == "Buy")
        {
            people.SetActive(true);
            tank.SetActive(true);
            helicopter.SetActive(true);
            isMouseEnter = true;
            isMouseExit = false;
        }
    }
}
