using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public SpriteRenderer countdownSprite;
    public GameObject countDownObject;
    public Sprite[] countdownSprites;
    public float countdownDuration = 4f;
    private GameManager gameManager; // GameManagerへの参照
    private GameStateController gameStateController; 

    void Awake()
    {
        gameStateController = FindObjectOfType<GameStateController>();
        gameManager = FindObjectOfType<GameManager>();
        gameStateController.SetCountdownState();
    }

    private void Start()
    {
        if (gameManager != null && gameManager.CurrentState == GameManager.GameState.Countdown)
        {
            StartCoroutine(StartCountdown());
            countDownObject.SetActive(true);
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
