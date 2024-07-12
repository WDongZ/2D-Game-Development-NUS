using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // 指向黑色全屏 Image
    public float fadeDuration = 1.0f; // 淡出持续时间
    public string sceneName;

    // 调用此方法开始淡出并切换场景
    public void FadeOutAndSwitchScene()
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeOut(string sceneName)
    {
        // 渐变淡出
        float elapsedTime = 0.0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // 完成淡出后切换场景
        SceneManager.LoadScene(sceneName);
    }
}
