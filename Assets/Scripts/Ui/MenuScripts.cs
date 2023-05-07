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

    /*
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    */

}
