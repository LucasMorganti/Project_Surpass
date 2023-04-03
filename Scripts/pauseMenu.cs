using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseM;

    public AudioSource musicPlayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseM.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        musicPlayer.mute = false;
        Cursor.visible = false;
    }

    void PauseGame()
    {
        pauseM.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        musicPlayer.mute = true;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
