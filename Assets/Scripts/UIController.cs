using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameClearMenu;
    public GameObject countdownDisplay;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        switch (gameManager.CurrentState)
        {
            case GameManager.GameState.Pause:
                SetMenuActive(pauseMenu, true);
                break;
            case GameManager.GameState.GameOver:
                SetMenuActive(gameOverMenu, true);
                break;
            case GameManager.GameState.GameClear:
                SetMenuActive(gameClearMenu, true);
                break;
            case GameManager.GameState.Countdown:
                SetMenuActive(countdownDisplay, true);
                break;
            default:
                SetAllMenusInactive();
                break;
        }
    }

    private void SetMenuActive(GameObject menu, bool isActive)
    {
        if (menu != null)
            menu.SetActive(isActive);
    }

    private void SetAllMenusInactive()
    {
        SetMenuActive(pauseMenu, false);
        SetMenuActive(gameOverMenu, false);
        SetMenuActive(gameClearMenu, false);
        SetMenuActive(countdownDisplay, false);
    }

}
