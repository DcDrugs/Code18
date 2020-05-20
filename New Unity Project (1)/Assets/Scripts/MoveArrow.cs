using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    public float angle;

    public bool isDown, isLeft, isRight, isForward;

    public MoveArrow leftArrow, rightArrow, forwardArrow, downArrow;

    private static float _epsilon = 10f;

    public GameObject target;

    public MoveArrow NextGameObject;

    public MoveArrow firstObject;

    public GameObject leftDots, rightDots, forwardDots, downDots;

    public MoveArrow nextMoveArrow;

    public GameObject point;

    public bool isObjectActive;

    private LoockAtWay _loockAtWay;
    enum LoockAtWay
    {
        right,
        left,
        down,
        forward,
    };

    void Start()
    {
        _loockAtWay = GetLoockAtWay();
        SetNextArrow();
    }

    void SetNextArrow()
    {
        switch (_loockAtWay)
        {
            case LoockAtWay.forward:
                nextMoveArrow = forwardArrow;
                break;
            case LoockAtWay.left:
                nextMoveArrow = leftArrow;
                break;
            case LoockAtWay.right:
                nextMoveArrow = rightArrow;
                break;
            case LoockAtWay.down:
                nextMoveArrow = downArrow;
                break;
        }
    }

    private LoockAtWay GetLoockAtWay()
    {
        if (Mathf.Abs(angle - 90) < _epsilon)
        {
            angle = 90;
            return LoockAtWay.forward;
        }
        else if (Mathf.Abs(angle) < _epsilon)
        {
            angle = 0;
            return LoockAtWay.right;
        }
        if (Mathf.Abs(angle - 270) < _epsilon)
        {
            angle = 270;
            return LoockAtWay.down;
        }
        else
        {
            angle = 180;
            return LoockAtWay.left;
        }
    }

    private float GetAngle(LoockAtWay obj, bool next, bool nextNext)
    {
        if (_loockAtWay == obj)
        {
            if (next)
            {
                angle += 90;
            }
            else if (nextNext)
            {
                angle += 180;
            }
            else
            {
                angle += 270;
            }
        }
        if (angle >= 355)
            angle -= 360;
        return angle;
    }

    void OnMouseUpAsButton()
    {
            angle = transform.localEulerAngles.z;
            _loockAtWay = GetLoockAtWay();
            angle = GetAngle(LoockAtWay.forward, isLeft, isDown);
            angle = GetAngle(LoockAtWay.right, isForward, isLeft);
            angle = GetAngle(LoockAtWay.down, isRight, isForward);
            angle = GetAngle(LoockAtWay.left, isDown, isRight);
            _loockAtWay = GetLoockAtWay();
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            CleanAllTarget();
            SetActiveAllTarget();
            SetDeactivetedAllTarget();
    }

    private void CleanAllTarget()
    {
        firstObject.DeleteTarget();
    }

    private void DeleteTarget()
    {
        if (forwardDots != null)
            forwardDots.SetActive(false);
        if (leftDots != null)
            leftDots.SetActive(false);
        if (rightDots != null)
            rightDots.SetActive(false);
        if (downDots != null)
            downDots.SetActive(false);

        if (gameObject.name != "Arrow1")
            target = null;
        if (NextGameObject != null)
            NextGameObject.DeleteTarget();
    }

    private void SetActiveAllTarget()
    {
        firstObject.SetActiveArrow();
    }

    private void SetActiveArrow()
    {
        _loockAtWay = GetLoockAtWay();
        switch (_loockAtWay)
        {
            case LoockAtWay.forward:
                if (forwardArrow.target == null)
                {
                    forwardArrow.target = gameObject;
                    forwardArrow.SetActiveArrow();
                }
                nextMoveArrow = forwardArrow;
                forwardDots.SetActive(true);
                break;
            case LoockAtWay.left:
                if (leftArrow.target == null)
                {
                    leftArrow.target = gameObject;
                    leftArrow.SetActiveArrow();
                }
                nextMoveArrow = leftArrow;
                leftDots.SetActive(true);
                break;
            case LoockAtWay.right:
                if (rightArrow.target == null)
                {
                    rightArrow.target = gameObject;
                    rightArrow.SetActiveArrow();
                }
                nextMoveArrow = rightArrow;
                rightDots.SetActive(true);
                break;
            case LoockAtWay.down:
                if (downArrow.target == null)
                {
                    downArrow.target = gameObject;
                    downArrow.SetActiveArrow();
                }
                nextMoveArrow = downArrow;
                downDots.SetActive(true);
                break;
        }
    }

    private void SetDeactivetedAllTarget()
    {
        firstObject.SetDeactivetedArrow();
    }

    void SetDeactivetedArrow()
    {
        if (target == null)
        {
            isObjectActive = false;
            gameObject.SetActive(false);
        }
        else
        {
            isObjectActive = true;
            gameObject.SetActive(true);
        }
        if (NextGameObject != null)
            NextGameObject.SetDeactivetedArrow();
    }
}
