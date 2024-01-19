using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // プレイヤーの移動速度
    private GameManager gameManager; // GameManagerへの参照
    private PlayerKnockBack playerKnockBack;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerKnockBack = GetComponent<PlayerKnockBack>();
    }

    private void Update()
    {
        if (gameManager != null && gameManager.CurrentState == GameManager.GameState.Playing && !playerKnockBack.isKnockedBack)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
            transform.position += movement * speed * Time.deltaTime;
        }
    }
}
