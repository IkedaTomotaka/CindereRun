using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController2 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject targetObject;

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        targetObject.SetActive(true);
    }

}
