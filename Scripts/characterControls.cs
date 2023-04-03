using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Playables;
using Cinemachine;

public class characterControls : MonoBehaviour
{

    public float MAX_HP = 100;
    public float damagePerSecondOnPoison = 3;
    public float damagePeriodOnPoison = 1;
    public Image lifeBar;
    public TextMeshProUGUI scoreGUI;
    private float hp;
    private float timer;
    public Animator fadeToBlack;
    public PlayableDirector director;
    public GameObject player;
    public GameObject gameHUD;
    public GameObject pauseMenu;
    public TextMeshProUGUI fim;
    public GameObject canvas;
    public GameObject canvas2;
    //public PlayableDirector play1;
    //public PlayableDirector play2;


    // Start is called before the first frame update
    void Start()
    {
        hp = MAX_HP;
        lifeBar.fillAmount = hp / MAX_HP;
        timer = 0;
        director.Stop();
        fadeToBlack.enabled = false;
        fim.enabled = false;
        canvas.SetActive(false);
        canvas2.SetActive(false);
        Cursor.visible = false;
        //play1.enabled = false;
        //play2.enabled = false;
    }

    public void ResumeGame1()
    {
        Time.timeScale = 1f;
        canvas.SetActive(false);
        Cursor.visible = false;
    }

    public void ResumeGame2()
    {
        Time.timeScale = 1f;
        canvas2.SetActive(false);
        Cursor.visible = false;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("health"))
        {
            hp += 10;
            if (hp > MAX_HP)
            {
                hp = MAX_HP;
            }
            lifeBar.fillAmount = hp / MAX_HP;
            Destroy(other.gameObject);
            //play1.enabled = true;
            //florAnim.SetBool("flor ivda", true);

           // florAnim2.enabled = true;
        }

        if (other.gameObject.CompareTag("portal"))
        {
            player.SetActive(false);
            gameHUD.SetActive(false);
            pauseMenu.SetActive(false);
            director.Play();
            fadeToBlack.enabled = true;
            fim.enabled = true;
        }

        if (other.gameObject.CompareTag("text"))
        {
            Time.timeScale = 0f;
            canvas.SetActive(true);
            canvas2.SetActive(false);
            Cursor.visible = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("text2"))
        {
            Time.timeScale = 0f;
            canvas2.SetActive(true);
            canvas.SetActive(false);
            Cursor.visible = true;
            Destroy(other.gameObject);
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("poison"))
        {
            // IMPORTANTE: Como contar o tempo entre os frames no Unity
            timer = timer + Time.deltaTime;
            if (timer >= damagePeriodOnPoison)
            {
                timer = 0;
                hp = hp - damagePerSecondOnPoison;
                if (hp <= 0)
                {
                    SceneManager.LoadScene(0);
                }
                lifeBar.fillAmount = hp / MAX_HP;
            }
            //play2.enabled = true;

            //florAnim.SetBool("opoppopoo", true);

           // florAnim.enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("poison"))
        {
           // play2.enabled = false;
           // timer = 0;
            //florAnim.enabled = false;
        }

        if (other.gameObject.CompareTag("health"))
        {
           // play1.enabled = false;
            //florAnim2.enabled = false;
        }
    }
}
