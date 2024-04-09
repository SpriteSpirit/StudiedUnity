using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;


public class GameManagerTest : MonoBehaviour
{
    public static GameManagerTest instance;
    private TargetList list;
    [SerializeField] private Text levelsText;
    [SerializeField] private Text scoreText;
    public int score; // ������ ��������� ��������, ��� ���������� ����� �������.
    public bool isNext;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // �������� �� ������� �������� ����� �����.
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // ������� �� �������.
    }

    // �����, ������� ����� ������ ����� �������� ����� �����
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindAndInitializeUI();
        list = GameObject.Find("Main Camera").GetComponent<TargetList>();
        isNext = list.levelLoaded;
    }

    private void FindAndInitializeUI()
    {
        // ����� ��������� UI �� ����� �����
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        levelsText = GameObject.Find("Levels").GetComponent<Text>();

        if (scoreText == null || levelsText == null)
        {
            Debug.LogError("�� ������� ����� ���� �� ��������� UI.");
            return;
        }

        // ���������� ������ UI � �������� ����������
        UpdateUI();
    }

    private void Start()
    {
        // �� �������� ���� ����� ����� ��� ������������� UI ��������� �� ������ ����.
        FindAndInitializeUI();
        isNext = list.levelLoaded;
    }

    private void FixedUpdate()
    {
        UpdateUI();
        LoadNextLevel();
    }

    // ���������� UI ���������
    private void UpdateUI()
    {
        if (scoreText != null) // ���������, �� �������� �� �� ������ �� scoreText.
        {
            scoreText.text = "SCORE: " + score.ToString();
        }

        if (levelsText != null)
        {
            levelsText.text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex + 1).ToString();
        }
    }

    private void LoadNextLevel()
    {
        if (list.animals.Count == 0 && !isNext)
        {
            Debug.Log(SceneManager.sceneCountInBuildSettings);
            Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
            isNext = !list.levelLoaded;
            // if (SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCountInBuildSettings)
            // {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // }
        }
    }

    private void OnDestroy()
    {
        // ������������ �� �������, ����� �������� ������ ������.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}




