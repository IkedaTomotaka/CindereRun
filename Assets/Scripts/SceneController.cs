using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    // タイトルシーンへ遷移
    public void GoToTitleScene()
    {
        SceneManager.LoadScene("Title");
        gameManager.ChangeState(GameManager.GameState.Start);
    }

    // 次のステージへ遷移
    public void GoToNextStage()
    {
        // 次のステージのシーン名を指定
        SceneManager.LoadScene("NextStageSceneName");
        gameManager.ChangeState(GameManager.GameState.Playing);
    }

    // ゲームオーバーシーンへ遷移
    public void GoToGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
        gameManager.ChangeState(GameManager.GameState.GameOver);
    }

    // ゲームクリアシーンへ遷移
    public void GoToGameClearScene()
    {
        SceneManager.LoadScene("GameClear");
        gameManager.ChangeState(GameManager.GameState.GameClear);
    }

    // ゲームを再スタート
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameManager.ChangeState(GameManager.GameState.Playing);
    }
}
