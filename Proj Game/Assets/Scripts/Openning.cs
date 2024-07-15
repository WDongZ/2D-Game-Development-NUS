using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Openning : MonoBehaviour
{
    public Image blackScreen;
    public float fadeDuration = 2f;
    private float currentAlpha = 0f;
    private bool isFading = false;
    public int nextScene;

    void Update()
    {
        if (isFading)
        {
            currentAlpha -= Time.deltaTime / fadeDuration;
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.Clamp01(currentAlpha));

            if (currentAlpha <= 0)
            {
                isFading = false;
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    public void StartFade()
    {
        currentAlpha = 1f;
        isFading = true;
    }
}
