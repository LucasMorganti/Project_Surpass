using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    public float rollingSpeed = 150;
    public float offScreenPositionY = 1539;
    private RectTransform credits;

    public void Start()
    {
        credits = GetComponent<RectTransform>();       
    }

    public void Update()
    {
        credits.Translate(0, Time.deltaTime * rollingSpeed, 0);
        float y = credits.anchoredPosition.y;
        if (y >= offScreenPositionY)
            SceneManager.LoadScene(0);
    }
}
