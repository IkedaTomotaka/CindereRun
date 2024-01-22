using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuNavigationController : MonoBehaviour
{
    // GameManagerへの参照
    public GameManager gameManager;

    // 各状態でデフォルトで選択されるボタン
    public GameObject defaultPauseButton;     // Pause状態でのデフォルトボタン
    public GameObject defaultGameOverButton;  // GameOver状態でのデフォルトボタン
    public GameObject defaultGameClearButton; // GameClear状態でのデフォルトボタン
    public GameObject defaultGameStartButton; // Start状態でのデフォルトボタン

    private GameObject lastSelectedButton; // 最後に選択されたボタン
    public GameStateController gameStateController; // GameStateControllerへの参照

    //private float lastVerticalInput = 0; // 前回の垂直入力値を記録

    private void Awake()
    {
      gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // ゲーム状態の変更をチェックし、UIを更新
        CheckForStateChange();

        // 垂直方向の入力を取得
        /*float verticalInput = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(verticalInput) > 0.1f && Mathf.Abs(lastVerticalInput) < 0.1f)
        {
            // 入力が変わった瞬間だけボタンナビゲーションを更新
            NavigateThroughButtons(verticalInput);
        }
        lastVerticalInput = verticalInput;*/ // 垂直入力値を更新
    }

    private void CheckForStateChange()
    {
        // ゲームの状態変更を確認し、対応するデフォルトボタンを選択
        switch (gameManager.CurrentState)
        {
            case GameManager.GameState.Pause:
                SelectDefaultButtonIfChanged(defaultPauseButton);
                break;
            case GameManager.GameState.Credit:
                SelectDefaultButtonIfChanged(defaultPauseButton);
                break;
            case GameManager.GameState.GameOver:
                SelectDefaultButtonIfChanged(defaultGameOverButton);
                break;
            case GameManager.GameState.GameClear:
                SelectDefaultButtonIfChanged(defaultGameClearButton);
                break;
            case GameManager.GameState.Start:
                SelectDefaultButtonIfChanged(defaultGameStartButton);
                break;
        }
    }

    /*private void NavigateThroughButtons(float input)
    {
        // ボタン間のナビゲーションを処理
        Selectable currentSelectable = EventSystem.current.currentSelectedGameObject?.GetComponent<Selectable>();
        if (currentSelectable != null)
        {
            Selectable nextSelectable = input > 0 ? currentSelectable.FindSelectableOnUp() : currentSelectable.FindSelectableOnDown();
            if (nextSelectable != null)
            {
                nextSelectable.Select();
                lastSelectedButton = nextSelectable.gameObject;
            }
        }
    }*/

    private void SelectDefaultButtonIfChanged(GameObject defaultButton)
    {
        // 指定されたデフォルトボタンが現在選択されているボタンと異なる場合、選択状態にする
        if (lastSelectedButton != defaultButton)
        {
            SetButtonSelected(defaultButton);
        }
    }

    private void SetButtonSelected(GameObject button)
    {
        // 指定されたボタンを選択状態にする
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
        lastSelectedButton = button;
    }
}
