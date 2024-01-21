using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public GameObject buttonA;       // ポーズ画面で表示するボタンA
    public GameObject buttonB;       // ポーズ画面で表示するボタンB
    public Text gamePauseText;       // ポーズメッセージを表示するテキスト
    public GameManager gameManager;  // GameManagerへの参照
    public GameStateController gameStateController; // GameStateControllerへの参照
    private List<ObjSetActive> objSetActiveList = new List<ObjSetActive>();

    private void Awake()
    {
        // シーン遷移時にGameManagerの参照を再取得する
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        // 現在のシーン名を取得
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 特定のシーンでのみAnimatorを取得する
        if (currentSceneName == "Stage3")
        {
        
            // シーン内のすべてのObjSetActiveを検索してリストに追加
            objSetActiveList.AddRange(FindObjectsOfType<ObjSetActive>());
        }
    }

    void Start()
    {
        // 初期状態ではUI要素を非アクティブにする
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        gamePauseText.gameObject.SetActive(false);
    }

    private void Update()
    {
        //objSetActiveList.AddRange(FindObjectsOfType<ObjSetActive>());
        // キャンセルボタン（多くの場合はエスケープキー）が押されたかどうかをチェック
        if (Input.GetButtonDown("Cancel"))
        {
            // 現在のゲームの状態がPlayingの場合、ポーズ状態を切り替える
            if (gameManager.CurrentState == GameManager.GameState.Playing)
            {
                gameStateController.SetPauseState();
            }
        }

        // ゲームの状態がポーズに変更されたかどうかをチェックし、UIを更新
        if (gameManager.CurrentState == GameManager.GameState.Pause)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void ReStart()
    {
        // ゲームを再開するためにPlaying状態に設定
        gameStateController.SetPlayingState();

        // 現在のシーン名を取得
        string currentSceneName = SceneManager.GetActiveScene().name;

        // 特定のシーンでのみ以下の処理を実行
        if (currentSceneName == "Stage3")
        {
            // すべてのObjSetActiveオブジェクトに対して操作を行う
            foreach (var objSetActive in objSetActiveList)
            {
                objSetActive.AnimStart(); // 仮にObjSetActiveにAnimStartメソッドがあるとします
            }
        }
    }

    public void Pause()
    {
        // ゲームの時間を停止し、ポーズUIを表示
        buttonA.SetActive(true);
        buttonB.SetActive(true);
        gamePauseText.gameObject.SetActive(true);
    }

    public void Resume()
    {
        // ゲームの時間を再開し、ポーズUIを非表示にする
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        gamePauseText.gameObject.SetActive(false);
    }
}
