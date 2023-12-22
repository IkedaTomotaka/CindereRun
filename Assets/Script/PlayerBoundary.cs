using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerBoundary : MonoBehaviour
{
    private Camera mainCamera;

    private float upperYBoundaryOffset = 5.2f; // Y軸の最大値オフセット
    private float minX = -2.9f;                // X軸の最小値
    private float maxX = 2.9f;                 // X軸の最大値

    private void Start()
    {
        mainCamera = Camera.main; // メインカメラを取得
    }

    private void Update()
    {
        RestrictMovement(); // プレイヤーの移動範囲を制限
    }

    void RestrictMovement()
    {
        Vector3 currentPosition = transform.position;

        // Y軸の最大値を計算
        float maxY = mainCamera.transform.position.y + upperYBoundaryOffset;

        // Y軸の最大値のみ制限し、X軸の位置も制限
        currentPosition.y = Mathf.Min(currentPosition.y, maxY); // Y軸の最大値のみ制限
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX); // X軸の位置を制限

        transform.position = currentPosition; // 制限された位置をプレイヤーに適用
    }
}
