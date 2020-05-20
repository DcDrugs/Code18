using System.Collections;
using UnityEngine;

public class RemovePlayer : MonoBehaviour
{
    public GameObject gameIntefrace;

    private GameObject gameObj;

    public string position;

    public void RemovePositionAndPlayer(GameObject gameObjectDestroy)
    {
        gameObj = gameObjectDestroy;
        position = gameObj.GetComponent<HealthBarUnit>().position;
        PositionController positionController = GetComponent<PositionController>();
        switch (position)
        {
            case "Position1":
                positionController.isPosition1Active = false;
                DestoyGameObject("Block1");
                break;
            case "Position2":
                positionController.isPosition2Active = false;
                DestoyGameObject("Block2");
                break;
            case "Position3":
                positionController.isPosition3Active = false;
                DestoyGameObject("Block3");
                break;
            case "Position4":
                positionController.isPosition4Active = false;
                DestoyGameObject("Block4");
                break;
            case "Position5":
                positionController.isPosition5Active = false;
                DestoyGameObject("Block5");
                break;
        }

    }

    void DestoyGameObject(string Block)
    {
        gameIntefrace.transform.Find(Block).Find(gameObj.tag).gameObject.SetActive(false);
        gameObj.tag = "Untagged";
        DieAnimation dieAnimation = transform.Find(position).GetComponent<DieAnimation>();
        dieAnimation.obj = gameObj;
        dieAnimation.destroyGameObject = gameObj;
        dieAnimation.enabled = true;
    }
}
