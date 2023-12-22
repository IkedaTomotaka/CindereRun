using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float maxY; // カメラが垂直方向に移動する最大値
    public float moveDuration; // カメラの垂直移動にかける時間
    public float minX; // カメラの水平方向の最小値
    public float maxX; // カメラの水平方向の最大値

    private GameManager gameManager;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float elapsedTime;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        initialPosition = transform.position;
        targetPosition = new Vector3(transform.position.x, initialPosition.y + maxY, transform.position.z);
        elapsedTime = 0f;
    }

    private void Update()
    {
        // GameStateがPlayingの時のみ、カメラを移動させる
        if (gameManager.CurrentState == GameManager.GameState.Playing)
        {
            elapsedTime += Time.deltaTime;
            MoveCameraVertically(); // 垂直移動処理
            MoveCameraHorizontally(); // 水平移動処理
        }
    }

    void MoveCameraVertically()
    {
        // カメラを垂直に移動させる
        transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);

        // カメラが目的地に到着したら、その場で停止
        if (elapsedTime >= moveDuration)
        {
            transform.position = targetPosition;
        }
    }

    void MoveCameraHorizontally()
    {
        // プレイヤーの位置を取得
        Vector3 playerPosition = FindObjectOfType<PlayerMovement>().transform.position;
        // カメラの新しいX座標を計算
        float newX = Mathf.Clamp(playerPosition.x, minX, maxX);
        // 現在のカメラ位置と新しい位置との間で滑らかに補間
        Vector3 newCameraPosition = new Vector3(newX, transform.position.y, transform.position.z);
        // カメラの位置を更新
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
