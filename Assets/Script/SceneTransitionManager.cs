using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneTransitionManager : MonoBehaviour
{
    private float step_time;
    public float ReturnTitleTime;
    private GameManager gameManager;

    [Header("Scene Names")]
    public string retrySceneName; // リトライ時に遷移するシーン名
    public string nextSceneName;  // 次のステージへ進む時のシーン名
    public string titleSceneName; // タイトル画面へ戻る時のシーン名
    public GameStateController gameStateController; // GameStateControllerへの参照

    [Header("State Change After Transition")]
    public GameManager.GameState stateAfterRetry = GameManager.GameState.Playing;
    public GameManager.GameState stateAfterNext = GameManager.GameState.Playing;
    public GameManager.GameState stateAfterTitle = GameManager.GameState.Start;

    void Start()
    {
      step_time = 0.0f;
      gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.CurrentState == GameManager.GameState.Start)
        {
        if (Input.GetButtonDown("Cancel"))
        {
        StartCoroutine(TransitionScene(nextSceneName, stateAfterNext));
        }
        step_time += Time.deltaTime;

        if(step_time >= ReturnTitleTime)
        {
          Title();
          //Debug.Log("akrgna");
        }

        }
        if (gameManager.CurrentState == GameManager.GameState.Epilogue ||gameManager.CurrentState == GameManager.GameState.Prologue)
        {
        if (Input.GetButtonDown("Cancel"))
        {
            Title();
        }

        }
    }

    // リトライボタンが押されたときの処理
    public void Retry()
    {
        StartCoroutine(TransitionScene(retrySceneName, stateAfterRetry));
    }

    // 次のステージへ進むボタンが押されたときの処理
    public void Next()
    {
        StartCoroutine(TransitionScene(nextSceneName, stateAfterNext));
    }

    // タイトルへ戻るボタンが押されたときの処理
    public void Title()
    {
        StartCoroutine(TransitionScene(titleSceneName, stateAfterTitle));
    }

    // シーン遷移とゲーム状態の変更を行うコルーチン
    private IEnumerator TransitionScene(string sceneName, GameManager.GameState newState)
    {
        yield return new WaitForSeconds(1f); // 1秒待機
        SceneManager.LoadScene(sceneName); // シーンをロード
        ChangeGameState(newState); // ゲーム状態を変更
    }

    // ゲーム状態を変更する関数
    private void ChangeGameState(GameManager.GameState newState)
    {
        switch (newState)
        {
            case GameManager.GameState.Start:
                gameStateController.SetStartState();
                break;
            case GameManager.GameState.Playing:
                gameStateController.SetPlayingState();
                break;
            case GameManager.GameState.GameOver:
                gameStateController.SetGameOverState();
                break;
            case GameManager.GameState.GameClear:
                gameStateController.SetGameClearState();
                break;
            case GameManager.GameState.Pause:
                gameStateController.SetPauseState();
                break;
            case GameManager.GameState.Countdown:
                gameStateController.SetCountdownState();
                break;
            case GameManager.GameState.Prologue:
                gameStateController.SetPrologueState();
                break;
            case GameManager.GameState.Epilogue:
                gameStateController.SetEpilogueState();
                break;
            // 他の状態についても同様に処理を追加
        }
    }
}

#if UNITY_EDITOR
// カスタムインスペクターを使用して、Unityエディターでの表示をカスタマイズ
[CustomEditor(typeof(SceneTransitionManager))]
public class SceneTransitionManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SceneTransitionManager script = (SceneTransitionManager)target;

        // ドロップダウンリストで状態を選択可能にする
        script.stateAfterRetry = (GameManager.GameState)EditorGUILayout.EnumPopup("State After Retry", script.stateAfterRetry);
        script.stateAfterNext = (GameManager.GameState)EditorGUILayout.EnumPopup("State After Next", script.stateAfterNext);
        script.stateAfterTitle = (GameManager.GameState)EditorGUILayout.EnumPopup("State After Title", script.stateAfterTitle);
    }
}
#endif
