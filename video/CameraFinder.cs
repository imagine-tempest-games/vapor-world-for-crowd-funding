using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using VaporWorld.UI;

public class CameraFinder : MonoBehaviour
{
    public VideoPlayer vPlayer;

    private UIManager UIManager;

    public UnityEngine.Events.UnityEvent onFinish;

    // Start is called before the first frame update
    void Start()
    {
        vPlayer.targetCamera = Camera.main;

        vPlayer.loopPointReached += (v) =>
        {
            SceneManager.LoadScene(gameObject.scene.name);
            onFinish.Invoke();
        };
    }

    public void OnEnable()
    {
        UIManager = FindObjectOfType<UIManager>();

        UIManager.gameObject.SetActive(false);
    }
}
