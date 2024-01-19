using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameClearManager : MonoBehaviour
{
    public GameObject buttonA;       // GameClear画面で表示するボタンA
    public GameObject buttonB;       // GameClear画面で表示するボタンB
    public SpriteRenderer gameClearSprite;      // GameClearの画像ファイル
    
    public GameManager gameManager; // GameManagerへの参照
    private AnimManager animManager;

    private void Awake()
    {
        // シーン遷移時にGameManagerの参照を再取得する
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    private void Update()
    {
        // ゲームの状態がGameClearの場合、UIを表示
        if (gameManager.CurrentState == GameManager.GameState.GameClear)
        {
            ShowGameClearUI();

            // AnimManagerコンポーネントを取得
            animManager = FindObjectOfType<AnimManager>();
            if(animManager != null)
            {
                // 特定のオブジェクトのAnimatorを停止する
                GameObject targetObject1 = GameObject.Find("針_短針");
                GameObject targetObject2 = GameObject.Find("針_長針");
                GameObject targetObject3 = GameObject.Find("Player");
                List<GameObject> targetObject4List = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
                List<GameObject> targetObject5List = new List<GameObject>(GameObject.FindGameObjectsWithTag("chandelier"));

                List<GameObject> targetObjectsList = new List<GameObject>();
                targetObjectsList.Add(targetObject1);
                targetObjectsList.Add(targetObject2);
                targetObjectsList.Add(targetObject3);
                targetObjectsList.AddRange(targetObject4List);
                targetObjectsList.AddRange(targetObject5List);
                GameObject[] targetObjects = targetObjectsList.ToArray();

                foreach(GameObject targetObject in targetObjects)
                {
                    animManager.StopAnimation(targetObject);
                }

                /*GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemyObject in enemyObjects)
                {
                    animManager.StopAnimation(enemyObject);
                }*/
            }
        }
        else
        {
            // それ以外の場合、UIを非表示にする
            HideGameClearUI();
        }
    }

    void ShowGameClearUI()
    {
        // GameClear時のUI要素をアクティブにする
        buttonA.SetActive(true);
        buttonB.SetActive(true);
        gameClearSprite.gameObject.SetActive(true);
    }

    void HideGameClearUI()
    {
        // GameClearでない時のUI要素を非アクティブにする
        buttonA.SetActive(false);
        buttonB.SetActive(false);
        gameClearSprite.gameObject.SetActive(false);
    }
}
