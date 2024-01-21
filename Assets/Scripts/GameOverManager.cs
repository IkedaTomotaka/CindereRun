using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameOverManager : MonoBehaviour
{
    public GameObject buttonA;
    public GameObject buttonB;
    public SpriteRenderer gameOverSprite;       // GameOverの画像ファイル
    public SpriteRenderer gameOverText;
    public SpriteRenderer gameOverObike;
    public GameManager gameManager; // GameManagerへの参照
    private AnimManager animManager;

    private void Awake()
    {
        // シーン開始時にGameManagerコンポーネントを取得
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    private void Start()
    {
        // 初期状態ではUIを非アクティブにする
        SetGameOverUIActive(false);
    }

    private void Update()
    {
        if (gameManager.CurrentState == GameManager.GameState.GameOver)
        {
            SetGameOverUIActive(true);

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
            }
        }
        else
        {
            SetGameOverUIActive(false);
        }
    }

    // GameOverのUI要素のアクティブ・非アクティブを設定する関数
    private void SetGameOverUIActive(bool isActive)
    {
        buttonA.SetActive(isActive);
        buttonB.SetActive(isActive);
        gameOverSprite.gameObject.SetActive(isActive);
        gameOverText.gameObject.SetActive(isActive);
        gameOverObike.gameObject.SetActive(isActive);
    }
}
