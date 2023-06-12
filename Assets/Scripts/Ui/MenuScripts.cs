using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionsPanel;


    public void SetScene(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


    public void ShowOptions(bool isActive)
    {
        OptionsPanel.SetActive(isActive);
    }


    public void HideOptions(bool isActive)
    {
        OptionsPanel.SetActive(isActive);
    }

    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    public void FullscreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void WindowSize(int windowSizeIndex)
    {
        switch (windowSizeIndex)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;

            case 1:
                Screen.SetResolution(640, 360, Screen.fullScreen);

                break;

            case 2:
                Screen.SetResolution(1280, 768, Screen.fullScreen);

                break;

            case 3:
                Screen.SetResolution(1360, 768, Screen.fullScreen);

                break;

            case 4:
                Screen.SetResolution(1600, 900, Screen.fullScreen);

                break;

        }
    }
}
