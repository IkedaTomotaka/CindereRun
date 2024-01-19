using UnityEngine;

public class BGMCotroller : MonoBehaviour
{
    public AudioSource TitleBGM; // タイトル用のBGM
    public AudioSource StageBGM; // ステージ1用のBGM
    //public AudioSource Stage2BGM;
    //public AudioSource Stage3BGM;

    private GameManager gameManager;

    void Start()
    {
        // シーン開始時にGameManagerコンポーネントを取得
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

void Update()
{
    // GameManagerがnullでないことを確認する
    if (gameManager != null)
    {
        // GameManagerの現在の状態に基づいてBGMを再生または停止する
        switch (gameManager.CurrentState)
        {
            case GameManager.GameState.Start:
                // タイトル状態の場合、タイトルBGMを再生
                if (TitleBGM != null && !TitleBGM.isPlaying)
                {
                    if (StageBGM != null)
                        StageBGM.Stop();
                    
                    TitleBGM.Play();
                }
                break;
            case GameManager.GameState.Playing:
                // プレイ中の状態の場合、ステージBGMを再生
                if (StageBGM != null && !StageBGM.isPlaying)
                {
                    if (TitleBGM != null)
                        TitleBGM.Stop();
                    
                    StageBGM.Play();
                }
                break;
            default:
                // それ以外の状態では全てのBGMを停止
                if (TitleBGM != null)
                    TitleBGM.Stop();
                
                if (StageBGM != null)
                    StageBGM.Stop();
                
                break;
        }
    }
    else
    {
        Debug.LogError("GameManager is null.");
    }
}
}