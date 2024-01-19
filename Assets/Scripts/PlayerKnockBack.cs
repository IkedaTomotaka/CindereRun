using System.Collections;
using UnityEngine;

public class PlayerKnockBack : MonoBehaviour
{
    private Rigidbody2D rb;
    public float knockBackDuration = 0.2f; // ノックバックの持続時間
    public bool isKnockedBack { get; private set; } // ノックバック中かどうか

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isKnockedBack = false;
    }

    public void KnockBack(Vector2 direction, float force)
    {
        StartCoroutine(KnockBackRoutine(direction.normalized * force));
    }

    private IEnumerator KnockBackRoutine(Vector2 force)
    {
        isKnockedBack = true;
        float timer = 0;

        while (timer < knockBackDuration)
        {
            timer += Time.deltaTime;
            rb.velocity = force; // ノックバック中は速度を設定
            yield return null;
        }

        rb.velocity = Vector2.zero; // ノックバック終了後は速度をリセット
        isKnockedBack = false;
    }
}
