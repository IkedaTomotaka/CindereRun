using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CountdownController : MonoBehaviour
{
    public SpriteRenderer countdownSprite;
    public GameObject countDownObject;
    public GameObject ruleButton;
    public GameObject ruleImage;
    public Sprite[] countdownSprites;
    public float countdownDuration = 4f;
    private GameManager gameManager; // GameManagerへの参照
    private GameStateController gameStateController; 

    void Awake()
    {
        gameStateController = FindObjectOfType<GameStateController>();
        gameManager = FindObjectOfType<GameManager>();
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Stage3" || currentSceneName == "Stage2")
        {
            gameStateController.SetCountdownState();
        }
    }

    private void Start()
    {
        if (gameManager != null && gameManager.CurrentState == GameManager.GameState.Rule)
        {
            ruleButton.SetActive(true);
            ruleImage.SetActive(true);
            countDownObject.SetActive(false);
        }
        else
        {
            ruleButton.SetActive(false);
            ruleImage.SetActive(false);
            Count();
        }
    }

    private void Update()
    {
        if (gameManager != null && gameManager.CurrentState == GameManager.GameState.Rule)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                gameStateController.SetCountdownState();
                Count();
            }
        }
    }

    public void Count()
    {
        if (gameManager != null && gameManager.CurrentState == GameManager.GameState.Countdown)
        {
            StartCoroutine(StartCountdown());
            countDownObject.SetActive(true);
            ruleButton.SetActive(false);
            ruleImage.SetActive(false);
        }
        else
        {
            countDownObject.SetActive(false);
        }
    }

    IEnumerator StartCountdown()
    {
        //Debug.Log("iaigpan");
        for (int i = 0; i < countdownSprites.Length; i++)
        {
            countdownSprite.sprite = countdownSprites[i];
            yield return new WaitForSeconds(1f);
        }
        gameStateController.SetPlayingState();
        countDownObject.SetActive(false);

        //Debug.Log("Countdown Finished!");
    }
}
