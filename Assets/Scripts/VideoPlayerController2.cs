using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController2 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;
    [SerializeField] public float delayTime = 2f;
    public GameStateController gameStateController; // GameStateControllerへの参照
    void Start()
    {
        gameStateController = FindObjectOfType<GameStateController>();
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Invoke("LoadNextScene", delayTime);
    }

    void LoadNextScene()
    {
        gameStateController.SetStartState();
        SceneManager.LoadScene(nextSceneName);
    }
    
    /*
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
*/
}
