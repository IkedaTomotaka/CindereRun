using UnityEngine;

public class BGMCotroller : MonoBehaviour
{
    public AudioSource TitleBGM; // タイトル用のBGM
    public AudioSource PrologueBGM;
    public AudioSource Stage1BGM; // ステージ1用のBGM
    public AudioSource Stage2BGM;
    public AudioSource Stage3BGM;
    public AudioSource EpilogueBGM;

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
        // GameManagerの現在の状態に基づいてBGMを再生または停止する
        switch (gameManager.CurrentState)
        {
            case GameManager.GameState.Start:
                // タイトル状態の場合、タイトルBGMを再生
                if (!TitleBGM.isPlaying)
                {
                    Stage1BGM.Stop();
                    TitleBGM.Play();
                }
                break;
            case GameManager.GameState.Playing:
                // プレイ中の状態の場合、ステージBGMを再生
                if (!Stage1BGM.isPlaying)
                {
                    TitleBGM.Stop();
                    Stage1BGM.Play();
                }
                break;
            default:
                // それ以外の状態では全てのBGMを停止
                TitleBGM.Stop();
                Stage1BGM.Stop();
                break;
        }
    }
}
