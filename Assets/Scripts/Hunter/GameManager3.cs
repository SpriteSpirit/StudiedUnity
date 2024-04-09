using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;
    public int currentScore = 0;

    private void Awake()
    {
        // ���������, ���������� �� ��� ��������� GameManager
        if (instance == null)
        {
            // ���� ���, �� ������ ������� ��������� �������� �����������
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ���� ��� ���������� ������ ��������� GameManager, ���������� ����
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        currentScore += points;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", currentScore);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            currentScore = PlayerPrefs.GetInt("Score");
        }
        else
        {
            currentScore = 0;
        }
    }
}
