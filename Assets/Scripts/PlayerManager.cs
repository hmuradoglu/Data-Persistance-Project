using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public string playerName;
    public int highScore;

    public GameObject playerNameText;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

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
}
