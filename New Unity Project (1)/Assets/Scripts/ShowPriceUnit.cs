using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPriceUnit : MonoBehaviour
{
    public string gameName;

    public BuyArmy buyArmy;

    public RectTransform price;

    public PositionController positionController;

    public GameObject gamePrefab;

    private bool isMouseEnter, isMouseExit;

    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = this.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        
        if (isMouseEnter)
        {
            price.localPosition = Vector3.MoveTowards(price.localPosition,
                                                                new Vector3(15.2f, -0.76f, 0), 5);
        }
        if (price.localPosition == (new Vector3(15.2f, -0.76f, 0)))
        {
            isMouseEnter = false;
        }


        if (isMouseExit)
        {
            price.localPosition = Vector3.MoveTowards(price.localPosition,
                                                                new Vector3(9.6f, -0.76f, 0), 5);
        }
        if (price.transform.localPosition == (new Vector3(9.6f, -0.76f, 0)))
        {
            price.gameObject.SetActive(false);
            isMouseExit = false;
        }
    }

    public void OnMouseExit()
    {
        if (gameObject.name == gameName)
        {
            isMouseExit = true;
            isMouseEnter = false;
        }
    }

    public void OnMouseEnter()
    {
        if (gameObject.name == gameName)
        {
            buyArmy.OnMouseEnter();
            price.gameObject.SetActive(true);
            isMouseEnter = true;
            isMouseExit = false;
        }
    }

    public void OnMouseUpAsButton()
    {
        positionController.PlayerOnPosition(gamePrefab, int.Parse(price.GetComponent<Text>().text));
    }
}
