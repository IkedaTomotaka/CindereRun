using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // シングルトンの参照

    // ゲームの状態を示す列挙体
    public enum GameState
    {
        Start,      // ゲーム開始時の状態
        Playing,    // ゲームプレイ中の状態
        GameOver,   // ゲームオーバーの状態
        GameClear,  // ゲームクリアの状態
        Pause,       // ゲームポーズの状態
        Countdown,   //カウントダウンの状態
        Prologue,   //プロローグの状態
        Epilogue,    //エピローグの状態
        Credit, //クレジットの状態
    }

    public GameState CurrentState { get; set; }

    public GameState currentState = GameState.Start; // 初期状態を'Start'とする

    private void Awake()
    {
        // シングルトンパターンの実装
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.Start:
                // Start状態の時の処理
                break;
            case GameState.Playing:
                // Playing状態の時の処理
                break;
            case GameState.GameOver:
                // GameOver状態の時の処理
                break;
            case GameState.GameClear:
                // GameClearの時の処理
                break;
            case GameState.Pause:
                // Pauseの時の処理
                break;
            case GameState.Countdown:
                break;
            case GameState.Prologue:
                break;
            case GameState.Epilogue:
                break;
            case GameState.Credit:
                break;
        }

        //Debug.Log(currentState);
    }

    // 他のクラスから状態を変更するためのメソッド
    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }
}
