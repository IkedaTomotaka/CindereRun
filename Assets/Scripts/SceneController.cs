using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameManager gameManager;
    public GameStateController gameStateController;
    public string nextSceneName;
    public CountdownController countdownController;

    private void Awake()
    {
      gameManager = FindObjectOfType<GameManager>();
      gameStateController = FindObjectOfType<GameStateController>();
      countdownController = FindObjectOfType<CountdownController>();
    }

    // タイトルシーンへ遷移
    public void GoToTitleScene()
    {
        SceneManager.LoadScene("Title");
        gameStateController.SetStartState();
    }

    public void GoToTitleState()
    {
        gameStateController.SetStartState();
    }

    public void GotoStage1()
    {
        SceneManager.LoadScene("Stage1");
        gameStateController.SetRuleState();
    }

    // 次のステージへ遷移
    public void GoToNextStage()
    {
        // 次のステージのシーン名を指定
        SceneManager.LoadScene(nextSceneName);
        gameStateController.SetCountdownState();
    }

    public void GoToEpilogue()
    {
        SceneManager.LoadScene("epilogue");
        gameStateController.SetEpilogueState();
    }

    public void GoToCreditState()
    {
        gameStateController.SetCreditState();
    }
    
    public void GotoCountDown()
    {
        gameStateController.SetCountdownState();
        countdownController.Count();
    }

    // ゲームを再スタート
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameStateController.SetPlayingState();
    }
}
