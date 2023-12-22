using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public GameManager gameManager;  // GameManagerへの参照

    private void Awake()
    {
        // シーン開始時にGameManagerの参照を取得する
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    // この関数を、ゲームがクリアされた際（例: 全ての敵を倒す、目的地に到達するなど）に呼び出す。
    public void SetGameClearState()
    {
        gameManager.CurrentState = GameManager.GameState.GameClear;
        //Debug.Log("Game Clear State Set");
    }

    // この関数を、ゲームをクリアできなかった時に呼び出す。
    public void SetGameOverState()
    {
        gameManager.CurrentState = GameManager.GameState.GameOver;
        //Debug.Log("Game Over State Set");
    }

    // この関数を、ゲームをスタートする際に呼び出す。
    public void SetStartState()
    {
        gameManager.CurrentState = GameManager.GameState.Start;
        Debug.Log("Start State Set");
    }

    // この関数を、ゲームがプレイ中の状態にある時に呼び出す。
    public void SetPlayingState()
    {
        gameManager.CurrentState = GameManager.GameState.Playing;
        Debug.Log("Playing State Set");
    }

    // この関数を、ゲームを一時停止する際に呼び出す。
    public void SetPauseState()
    {
        if (gameManager != null)
        {
            gameManager.CurrentState = GameManager.GameState.Pause;
            //Debug.Log("Pause State Set");
        }
    }

    public void SetCountdownState()
    {
        if (gameManager != null)
        {
            gameManager.CurrentState = GameManager.GameState.Countdown;
            //Debug.Log("Countdown State Set");
        }
    }

    public void SetPrologueState()
    {
        if (gameManager != null)
        {
            gameManager.CurrentState = GameManager.GameState.Prologue;
            //Debug.Log("Prologue State Set");
        }
    }

    public void SetEpilogueState()
    {
        if (gameManager != null)
        {
            gameManager.CurrentState = GameManager.GameState.Epilogue;
            //Debug.Log("Epilogue State Set");
        }
    }
}
