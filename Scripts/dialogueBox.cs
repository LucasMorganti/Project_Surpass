using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueBox : MonoBehaviour
{
    public Image textoCorona;
    public Image textoVida;
    // Start is called before the first frame update
    void Start()
    {
        textoCorona.enabled = false;
        textoVida.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("text"))
        {
            Time.timeScale = 0f;
            textoCorona.enabled = true;
        }

        if (other.gameObject.CompareTag("text2"))
        {
            Time.timeScale = 0f;
            textoVida.enabled = true;
        }
    }

    public void ResumeGame1()
    {
        Time.timeScale = 1f;
        textoCorona.enabled = false;
    }

    public void ResumeGame2()
    {
        Time.timeScale = 1f;
        textoVida.enabled = false;
    }

}   
