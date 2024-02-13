using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text mainTimeText; // 通常の秒数用テキスト
    public TMP_Text fractionTimeText; // 小数点以下の秒数用テキスト
    public float timePenalty = 2.0f;
    public float timeBonus = 3.0f;
    public float startingTime = 60.0f;
    public GameObject bonusObject;
    public float stopTimer = 3.0f;
    public bool isStopTime { get; private set; }

    private float remainingTime;
    private GameStateController gameStateController; // GameStateControllerへの参照
    private GameManager gameManager;
    private AudioController audioController;
    private VerticalGradientChanger verticalGradientChanger;

    void Awake()
    {
        remainingTime = startingTime;
        gameStateController = FindObjectOfType<GameStateController>(); // GameStateControllerの参照を取得
        // GameManagerコンポーネントを取得して参照を設定
        gameManager = FindObjectOfType<GameManager>();
        audioController = FindObjectOfType<AudioController>();
        verticalGradientChanger = FindObjectOfType<VerticalGradientChanger>();

        UpdateTimeText();
    }


    void Update()
    {
        // タイムスケールが0でないことを確認するデバッグステートメントを追加
        if (Time.timeScale == 0)
        {
                    remainingTime = 0;
                    UpdateTimeText();
                    gameStateController.SetGameOverState();
                    audioController.PlayGameOverSE();
            //Debug.Log("Time.timeScale is 0, which means the game is paused or time is not moving.");
        }
        if (bonusObject.activeSelf == true)
        {
            if (remainingTime >= 5)
            {
                verticalGradientChanger.DefaltColor();
            }

            if (remainingTime < 5)
            {
                verticalGradientChanger.DangerColor();
            }
        }
        else
        {
            verticalGradientChanger.BonusColor();
        }

        // GameManagerの状態がPlayingのときのみ時間を更新する
        if (gameManager.CurrentState == GameManager.GameState.Playing && !isStopTime)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

                UpdateTimeText();
                
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                UpdateTimeText();
                gameStateController.SetGameOverState();
                audioController.PlayGameOverSE();
            }

                
            }
        }
    }

    void UpdateTimeText()
    {
        if (mainTimeText != null && fractionTimeText != null)
        {
            int seconds = Mathf.FloorToInt(remainingTime % 60); // 整数部分の秒数
            float fraction = remainingTime % 1.0f; // 小数点以下の部分

            mainTimeText.text = string.Format("{0:00}", seconds); // 整数部分のみを表示
            fractionTimeText.text = string.Format(".{0:00}", fraction * 100); // 小数点以下を表示
        }
    }


    public void SubtractTime()
    {
        remainingTime -= timePenalty;
        if (remainingTime <= 0)
        {
            remainingTime = 0;
            gameStateController.SetGameOverState();
            audioController.PlayGameOverSE();
        }
        UpdateTimeText();
    }

    public void AddTime(float timeAmount)
    {
        remainingTime += timeAmount;
        UpdateTimeText();
    }

    public float GetRemainingTime()
    {
        return remainingTime;
    }


    private void PlayGameOverSE()
    {
            audioController.PlayGameOverSE();
    }

    public void StopTime()
    {
        StartCoroutine(TheWorld());
    }

    IEnumerator TheWorld()
    {
        isStopTime = true;
        float timer = 0;

        while (timer < stopTimer)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        isStopTime = false;
    }
}