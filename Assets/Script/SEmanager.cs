using UnityEngine;

public class SEmanager : MonoBehaviour
{
    // サウンドエフェクト用のAudioSourceコンポーネント
    public AudioSource TimeBonusSE;
    public AudioSource GameClear1SE;
    public AudioSource GameClear2SE;
    public AudioSource GameOverSE;
    public AudioSource DamageSE;
    public AudioSource ClickSE;

    // ゲームオーバー時のサウンドエフェクトを再生
    public void PlayGameOverSE()
    {
        if (GameOverSE != null)
        {
            GameOverSE.Play();
        }
    }

    // 時間ボーナス時のサウンドエフェクトを再生
    public void PlayTimeBonusSE()
    {
        if (TimeBonusSE != null)
        {
            TimeBonusSE.Play();
        }
    }

    // ゲームクリア時のサウンドエフェクトを再生
    public void PlayGameClearSE()
    {
        if (GameClear1SE != null)
        {
            GameClear1SE.Play();
        }
    }

    // ダメージ受けた時のサウンドエフェクトを再生
    public void PlayDamageSE()
    {
        if (DamageSE != null)
        {
            DamageSE.Play();
        }
    }

    // クリック音のサウンドエフェクトを再生
    public void PlayClickSE()
    {
        if(ClickSE != null)
        {
            ClickSE.Play();
        }
    }
}
