using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditObj : MonoBehaviour
{
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject CreditImage;
    public SpriteRenderer gameCreditSprite;
    public GameManager gameManager;
    public GameStateController gameStateController; // GameStateControllerへの参照

    void Awake()
    {
        // シーン遷移時にGameManagerの参照を再取得する
        gameManager = FindObjectOfType<GameManager>();
        gameStateController = FindObjectOfType<GameStateController>();
        gameStateController.SetStartState();
    }
    // Start is called before the first frame update
    void Start()
    {     
        buttonA.SetActive(true);
        buttonB.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.CurrentState == GameManager.GameState.Start)
        {
            buttonA.SetActive(true);
            buttonB.SetActive(true);
        }
        else
        {
            buttonA.SetActive(false);
            buttonB.SetActive(false);
        }
        // 現在のゲームの状態がPlayingの場合、ポーズ状態を切り替える
        if (gameManager.CurrentState == GameManager.GameState.Credit)
        {
            CreditImage.SetActive(true);
            gameCreditSprite.gameObject.SetActive(true);
        }
        else
        {
            CreditImage.SetActive(false);   
            gameCreditSprite.gameObject.SetActive(false);
        }
    }
}
