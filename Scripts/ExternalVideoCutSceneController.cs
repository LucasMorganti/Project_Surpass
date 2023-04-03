using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;


public class ExternalVideoCutSceneController : MonoBehaviour
{
    public VideoPlayer vp;
    public RawImage rawImage;
    public Image lifeBar;
    public AudioSource musicPlayer;
    public GameObject mainCamera;


    public void Start()
    {
        rawImage.enabled = true;
        vp.Play();
        lifeBar.enabled = false;
        musicPlayer.enabled = false;
        mainCamera.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            vp.Stop();
            rawImage.enabled = false;
            lifeBar.enabled = true;
            musicPlayer.enabled = true;
            mainCamera.SetActive(true);
        }
    }
}
