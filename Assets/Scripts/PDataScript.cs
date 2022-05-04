using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PDataScript : MonoBehaviour
{
    public string playerName;

    public string[] playerNames;
    public int[] HighScoreValues;

    public static PDataScript Instance;

    public Color backgroundColor;

    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //load playernames and ascoited scores from sotred json file

    }

    public void getHighScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScores data = JsonUtility.FromJson<HighScores>(json);
            playerNames = data.playerNames;
            HighScoreValues = data.HighScoreValues;
            backgroundColor = data.Background;
        }
        else {
            playerNames = new string[10];
            HighScoreValues = new int[10];
            for (int i = 0; i < 10; i++) {
                playerNames[i] = " no NAme";
                HighScoreValues[i] = 0;
            }
        }
         
    }

    
    public void SaveHighScore(int highscore) {
        if (highscore > HighScoreValues[9]) {
            playerNames[9] = playerName;
            HighScoreValues[9] = highscore;

            for (int i = 9; i > 0; i--)
            {
                if (HighScoreValues[i] > HighScoreValues[i - 1])
                {
                    int tempscore = HighScoreValues[i];
                    string tempName = playerNames[i];

                    HighScoreValues[i] = HighScoreValues[i - 1];
                    playerNames[i] = playerNames[i - 1];

                    HighScoreValues[i - 1] = tempscore;
                    playerNames[i-1] = tempName;
                }
            }

        }

        HighScores data = new HighScores();
        data.playerNames = playerNames;
        data.HighScoreValues = HighScoreValues;
        data.Background = backgroundColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void setName(string name)
    {
        playerName = name;
    }

    public string getName()
    {
        return playerName;
    }

    [System.Serializable]
    public class HighScores {
       public string[] playerNames;
       public int[] HighScoreValues;
        public Color Background;
    }

    
}
