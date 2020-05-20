using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionController : MonoBehaviour
{
    public GameObject interfaceGameObject;

    public Transform position1, position2, position3, position4, position5;

    public GameObject targetPlayer;

    public SpawnPlayer spawnPlayer;

    public PlayerMove player;

    public GameObject loseMenu;

    public bool isPosition1Active, isPosition2Active, isPosition3Active, isPosition4Active, isPosition5Active;

    public Text textMoney;

    private int _armyPrice = -1;

    private float _saveSpeed;

    void Start()
    {
        _saveSpeed = player.speed;
        isPosition1Active = isPosition2Active = isPosition3Active = isPosition4Active = isPosition5Active = false;
    }

    void Update()
    {
        if (isPosition1Active == false && isPosition2Active == false &&
            isPosition3Active == false && isPosition4Active == false && isPosition5Active == false)
        {
            if (int.Parse(textMoney.text) < 100)
            {
                Time.timeScale = 0f;
                loseMenu.SetActive(true);
            }
            player.speed = 0;
        }
        else
        {
            player.speed = _saveSpeed;
        }
    }

    public bool isFreePosition()
    {
        if (!isPosition1Active)
            return true;

        if (!isPosition2Active)
            return true;

        if (!isPosition3Active)
            return true;
        
        if (!isPosition4Active)
            return true;

        if (!isPosition5Active)
            return true;

        return false;
    }
    public void PlayerOnPosition(GameObject setPlayerOnAPosition, int armyPrice)
    {
        targetPlayer = setPlayerOnAPosition;
        _armyPrice = armyPrice;
        if (!isPosition1Active)
        {
            SetPlayer(position1, ref isPosition1Active, "Block1", "Position1");
            return;
        }
        if(!isPosition2Active)
        {
            SetPlayer(position2, ref isPosition2Active, "Block2", "Position2");
            return;
        }
        if(!isPosition3Active)
        {
            SetPlayer(position3, ref isPosition3Active, "Block3", "Position3");
            return;
        }
        if(!isPosition4Active)
        {
            SetPlayer(position4, ref isPosition4Active, "Block4", "Position4");
            return;
        }
        if(!isPosition5Active)
        {
            SetPlayer(position5, ref isPosition5Active, "Block5", "Position5");
            return;
        }
    }

    void SetPlayer(Transform position,ref bool isPosition, string block, string positionName)
    {
        if (spawnPlayer.enabled == false)
        {
            int youMoney = int.Parse(textMoney.text);
            if (youMoney >= _armyPrice && _armyPrice != -1)
            {
                youMoney -= _armyPrice;
                _armyPrice = -1;
                textMoney.text = youMoney.ToString();
                interfaceGameObject.transform.Find(block).Find(targetPlayer.tag).gameObject.SetActive(true);
                spawnPlayer.spawnObj = targetPlayer;
                spawnPlayer.position = position;
                spawnPlayer.positionName = positionName;
                spawnPlayer.SpawnFunction();
                isPosition = true;
            }
        }
    }
} 