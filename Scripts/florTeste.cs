using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class florTeste : MonoBehaviour
{

    [SerializeField] private Animator aniMFlor;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("poison"))
        {
            aniMFlor.SetBool("teste", true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("poison"))
        {
            aniMFlor.SetBool("teste", false);
        }
    }
}
