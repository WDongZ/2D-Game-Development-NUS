using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // ָ���ɫȫ�� Image
    public float fadeDuration = 1.0f; // ��������ʱ��
    public string sceneName;

    // ���ô˷�����ʼ�������л�����
    public void FadeOutAndSwitchScene()
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeOut(string sceneName)
    {
        // ���䵭��
        float elapsedTime = 0.0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // ��ɵ������л�����
        SceneManager.LoadScene(sceneName);
    }
}
