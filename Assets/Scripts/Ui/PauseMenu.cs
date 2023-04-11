using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private InputAction pauseNavigation;
    private PlayerControlActions playerAction;

    public GameObject pauseMenuUI;


    private bool isPaused = false;

    private void Awake()
    {
        playerAction = new PlayerControlActions();
    }

    private void OnEnable()
    {
        pauseNavigation = playerAction.Player.PauseMenu;
        pauseNavigation.Enable();

        pauseNavigation.performed += Pause;
    }

    private void OnDisable()
    {
        pauseNavigation.Disable();
    }

    
    private void Pause(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    { 
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
