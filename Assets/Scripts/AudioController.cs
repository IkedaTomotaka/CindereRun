using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public AudioClip titleBGM;
    public AudioClip stageBGM;
    //public AudioClip gameOverBGM;
    //public AudioClip gameClearBGM;
    public AudioClip creditBGM;

    public AudioSource seAudioSource;
    public AudioClip timeBonusSE;
    public AudioClip gameClearSE;
    public AudioClip gameOverSE;
    public AudioClip damageSE;
    public AudioClip clickSE;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        switch (gameManager.CurrentState)
        {
            case GameManager.GameState.Start:
                PlayBGM(titleBGM);
                break;
            case GameManager.GameState.Playing:
                PlayBGM(stageBGM);
                break;
            /*case GameManager.GameState.GameOver:
                PlayBGM(gameOverBGM);
                break;
            case GameManager.GameState.GameClear:
                PlayBGM(gameClearBGM);
                break;*/
            case GameManager.GameState.Credit:
                PlayBGM(creditBGM);
                break;
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (bgmAudioSource.clip != clip)
        {
            bgmAudioSource.clip = clip;
            bgmAudioSource.Play();
        }
    }

    public void PlaySE(AudioClip clip)
    {
        seAudioSource.PlayOneShot(clip);
    }

    // 以下、個別のサウンドエフェクト用のメソッド
    public void PlayTimeBonusSE() { PlaySE(timeBonusSE); }
    public void PlayGameClearSE() { PlaySE(gameClearSE); }
    public void PlayGameOverSE() { PlaySE(gameOverSE); }
    public void PlayDamageSE() { PlaySE(damageSE); }
    public void PlayClickSE() { PlaySE(clickSE); }
}
