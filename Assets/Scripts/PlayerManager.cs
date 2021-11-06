using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    public TextMeshProUGUI bestScoreText;
    // public TextMeshProUGUI playerNameText;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();

        bestScoreText.text = "HighScore : " + highScorePlayerName + "(" + highScore + ")";

    }

    // "/Users/berrakmuradoglu/Documents/GitHub/Data-Persistance-Project/GamePlayerData.json"

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText("/Users/berrakmuradoglu/Documents/GitHub/Data-Persistance-Project/GamePlayerData.json", json);
    }

    public void LoadHighScore()
    {
        string path = "/Users/berrakmuradoglu/Documents/GitHub/Data-Persistance-Project/GamePlayerData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.playerName;
            highScore = data.highScore;
        }
    }

}
