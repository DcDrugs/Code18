using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRotation : MonoBehaviour
{
    public PlayerMove player;

    public GameObject winMenu;

    private bool isObjectRotate = false;

    private float speed;

    private MoveArrow target1, target2, target3, target4, target5;

    public GameObject position1, position2, position3, position4, position5;
    void Start()
    {
        target1 = target2 = target3 = target4 = target5 = player.target;
    }

    // Update is called once per frame
    void Update()
    {
        speed = player.speed;
        if (isObjectRotate == false)
        {
            if (!target1.gameObject.activeSelf || !target2.gameObject.activeSelf
                || !target3.gameObject.activeSelf || !target4.gameObject.activeSelf || !target5.gameObject.activeSelf)
            {
                return;
            }
            MovePositionOnPoint(position1.transform, target1.point.transform, speed);

            MovePositionOnPoint(position2.transform, target2.point.transform, speed);


            MovePositionOnPoint(position3.transform, target3.point.transform, speed);


            MovePositionOnPoint(position4.transform, target4.point.transform, speed);

            MovePositionOnPoint(position5.transform, target5.point.transform, speed);
            return;
        }

        
        RotatePosition(position1.transform, ref target1);
        RotatePosition(position2.transform, ref target2);
        RotatePosition(position3.transform, ref target3);
        RotatePosition(position4.transform, ref target4);
        RotatePosition(position5.transform, ref target5);

        if(target1.gameObject.tag == "End")
        {
            Time.timeScale = 0f;
            winMenu.SetActive(true);
        }
    }

    private void MovePositionOnPoint(Transform obj, Transform target, float localSpeed)
    {
        obj.position = Vector3.MoveTowards(obj.position,
                target.position + 9f * Vector3.up, Time.deltaTime * localSpeed);
        if (obj.position == (target.position + 9f * Vector3.up))
            isObjectRotate = true;

    }

    private void RotatePosition(Transform obj, ref MoveArrow target)
    {
        float angle = 360 - target.transform.localEulerAngles.z;
        if (obj.position == (target.point.transform.position + 9f * Vector3.up) && isObjectRotate == true)
        {
            obj.localRotation = Quaternion.RotateTowards(obj.localRotation,
                                                 Quaternion.Euler(0, angle, 0), Time.deltaTime * speed * 40);

            if (obj.localRotation == Quaternion.Euler(0, angle, 0))
            {
                isObjectRotate = false;
                target = target.nextMoveArrow;
                MovePositionOnPoint(obj, target.point.transform, 8);
            }

        }
    }
}
