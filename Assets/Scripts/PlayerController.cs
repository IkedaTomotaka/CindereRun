using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // プレイヤーの移動速度
    public Rigidbody2D rb; // プレイヤーのRigidbody
    private Vector2 movement; // 移動方向
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        // ゲーム状態がプレイ中の場合にのみ入力を受け付ける
        if (gameManager.CurrentState == GameManager.GameState.Playing)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        // 移動を適用
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void KnockBack(Vector2 direction, float force)
    {
        // ノックバックの効果を適用
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
