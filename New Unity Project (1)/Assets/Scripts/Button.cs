using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject MainCamera;

    public CameraControl _moveToPlayer;

    public CameraMoveToMap _moveToMap;

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Map":
                if (_moveToPlayer.enabled == false)
                    Time.timeScale = 1f;
                else
                    Time.timeScale = 0.1f;

                _moveToPlayer = MainCamera.GetComponent<CameraControl>();
                _moveToMap = MainCamera.GetComponent<CameraMoveToMap>();
                MainCamera.transform.Find("MapCanvas").gameObject.SetActive(false);
                MainCamera.transform.Find("GameInterface").gameObject.SetActive(true);
                _moveToMap.angle = _moveToPlayer.angle = MainCamera.transform.eulerAngles.x;
                _moveToPlayer.enabled = !_moveToPlayer.enabled;
                _moveToMap.enabled = !_moveToMap.enabled;
                break;
        }
    }
}