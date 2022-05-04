using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsUiScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBlue() {
        PDataScript.Instance.backgroundColor = Color.blue;
    }
    public void setGreen()
    {
        PDataScript.Instance.backgroundColor = Color.green;
    }
    public void setBlack()
    {
        PDataScript.Instance.backgroundColor = Color.black;
    }

    public void BackButton()
    {
        PDataScript.Instance.SaveHighScore(0);
        SceneManager.LoadScene(0);
    }
}
