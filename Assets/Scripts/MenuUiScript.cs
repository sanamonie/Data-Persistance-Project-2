using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUiScript : MonoBehaviour
{
    InputField nameField;


    // Start is called before the first frame update
    void Awake()
    {
        nameField = GameObject.Find("NameField").GetComponent<InputField>();
        PDataScript.Instance.getHighScores();

    }



    public void StartGame() {
        PDataScript.Instance.setName(nameField.text);
        SceneManager.LoadScene(1);
    }
    public void ShowHighScores() {
        SceneManager.LoadScene(3);
    }

    public void OpenSettings() {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }

}
