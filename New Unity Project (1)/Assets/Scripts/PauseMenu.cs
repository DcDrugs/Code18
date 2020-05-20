using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public  GameObject mapGameObject;

    public  GameObject interfaceGameObject;

    public  GameObject pauseMenuUI;

    public  CameraControl _cameraControl;

    public static bool _isActiveCameraCotrol;

    public  CameraMoveToMap _CameraMoveToMap;

    public static bool _isActiveMoveToMap;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        transform.Find("Map").gameObject.SetActive(true);
        _cameraControl.enabled = _isActiveCameraCotrol;
        _CameraMoveToMap.enabled = _isActiveMoveToMap;
        interfaceGameObject.SetActive(_isActiveCameraCotrol);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    private void Pause()
    {
        transform.Find("Map").gameObject.SetActive(false);
        _isActiveCameraCotrol = _cameraControl.enabled;
        _isActiveMoveToMap = _CameraMoveToMap.enabled;
        _cameraControl.enabled = false;
        _CameraMoveToMap.enabled = false;
        mapGameObject.SetActive(false);
        interfaceGameObject.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }


}
