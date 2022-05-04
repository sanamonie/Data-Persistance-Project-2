using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreUI : MonoBehaviour
{

    public Text HighScore;
    // Start is called before the first frame update
    void Start()
    {
        SetupHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupHighScores()
    {
        string highScoreText = "";
        for (int i = 0; i < 10; i++)
        {
            highScoreText += PDataScript.Instance.playerNames[i] + ": " + PDataScript.Instance.HighScoreValues[i] + System.Environment.NewLine;
        }
        HighScore.text = highScoreText;
    }

    public void BackButton() {
        SceneManager.LoadScene(0);
    }
}
