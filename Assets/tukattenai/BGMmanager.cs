using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMmanager : MonoBehaviour
{
    private static BGMmanager instance;

    public static BGMmanager Instance
    {
        get { return instance; }
    }

    public AudioClip Title;
    public AudioClip Stage1;
    public AudioClip Stage2;
    public AudioClip Stage3;
    public AudioClip TimeBonus;
    public AudioClip GameClear1;
    public AudioClip GameClear2;
    public AudioClip GameOver;
    public AudioClip Damage;
    public AudioClip se;

    private AudioSource audioSource;

    private static BGMmanager instance1;
    public static BGMmanager Instance1
    {
        get{return instance1;}
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayTitle()
    {
        PlaySE(Title);
    }
    public void PlayStage1SE()
    {
        PlaySE(Stage1);
    }

    public void StopStage1SE()
    {
        StopSE();
    }

    public void PlayStage2SE()
    {
        PlaySE(Stage2);
    }

    public void StopStage2SE()
    {
        StopSE();
    }

    public void PlayStage3SE()
    {
        PlaySE(Stage3);
    }

    public void StopStage3SE()
    {
        StopSE();
    }

    public void PlayTimeBonusSE()
    {
        PlaySE(TimeBonus);
    }

    public void PlayGameClearSE1()
    {
        PlaySE(GameClear1);
    }

    public void PlayGameClearSE2()
    {
        PlaySE(GameClear2);
    }

    public void PlayGameOverSE()
    {
        PlaySE(GameOver);
    }
    public void PlayDamageSE()
    {
        PlaySE(Damage);
    }

    public void PlaySE(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void StopSE()
    {
      if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}