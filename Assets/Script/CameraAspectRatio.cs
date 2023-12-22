using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectRatio : MonoBehaviour
{
    public float targetAspect = 1080.0f / 1920.0f; // 目標とするアスペクト比（縦型）

    void Start()
    {
        Camera camera = GetComponent<Camera>();

        // 現在の画面のアスペクト比を計算
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // スケールの高さを計算
        float scaleHeight = windowAspect / targetAspect;

        // カメラのviewportRectを調整
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}
