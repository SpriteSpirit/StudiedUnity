using UnityEngine;
using System.IO;

public class JSONManager : MonoBehaviour
{
    public int coinCount;
    public int lives;
    public int initialLives = 3;

    private void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        Data data = new Data { coinCount = coinCount, lives = lives };
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("game_data", json);
        PlayerPrefs.Save();

        Debug.Log("Saved");
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("game_data"))
        {
            string json = PlayerPrefs.GetString("game_data");
            Data data = JsonUtility.FromJson<Data>(json);

            if (data != null)
            {
                coinCount = data.coinCount;
                lives = data.lives;

                Debug.Log("Loaded");
            }
            else
            {
                Debug.LogError("Failed to load data");
            }
        }
        else
        {
            Debug.Log("No data to load");

            coinCount = 0;
            lives = initialLives;
        }
    }

    [System.Serializable]
    public class Data
    {
        public int coinCount;
        public int lives;
    }
}