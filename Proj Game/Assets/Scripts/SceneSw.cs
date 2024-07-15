using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class SceneSw : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
       
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
   
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

