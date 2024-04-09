using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager2 : MonoBehaviour
{
    [SerializeField] PlayerRunner player_movement;
    //[SerializeField] float levelRestartDelay = 2f; // ����� ������������ � ��������
    [SerializeField] Text time_text;
    [SerializeField] Text score_text;
    //private Camera main_camera;
    //private Camera death_camera;
    private Animator Animation;

    public int lives = 3;

    public Sprite sprite;
    public GameObject panel;


    [HideInInspector]
    public int score = 0;
    public int time = 0;

    public void game_over()
    {
        player_movement.enabled = false; // ��������� �������� ������
                                         // ����������� �������� ������ �� Death Camera
                                         //  main_camera.gameObject.SetActive(false);
                                         //  death_camera.gameObject.SetActive(true);
        Debug.Log("Game over");
        updateLifeUI();
        //Animation.Play("Die");
        // Invoke("RestartLevel", levelRestartDelay); // �������� ����� ������� ����� �����. �����
    }

    void RestartLevel()
    {
        StartCoroutine(timer(1.0f));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ������������� ������� �������
    }

    void Start()
    {
      //  main_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
      //  main_camera.gameObject.SetActive(true);

      //  death_camera = GameObject.FindGameObjectWithTag("DeathCamera").GetComponent<Camera>();
      //  death_camera.gameObject.SetActive(false);
        Animation = player_movement.GetComponent<Animator>();
        StartCoroutine(timer(1.0f));
    }

    public void updateLifeUI()
    {
        // ������� ��� ������������ ������� �� ������
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }

        // ������� � ���������� ������� ������ �� ������
        for (int i = 0; i < lives; i++)
        {
            GameObject live = new GameObject("LifeSprite");
            live.transform.SetParent(panel.transform);
            Image lifeSprite = live.AddComponent<Image>();
            lifeSprite.sprite = sprite; // ����� ���������� ��������� ������ ��� �����

            RectTransform rectTransform = live.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(60, 70);
        }
    }

    // ������ �����
    IEnumerator timer(float waitTime)
    {
        while (true)

        {
            yield return new WaitForSeconds(waitTime);
            // movement.runSpeed += movement.increaseSpeed;
            if (player_movement.enabled == false)
            {
                score_text.text = "SCORE: " + score.ToString();
                time_text.text = "TIME: " + time.ToString();
            }
            else
            {
                time++;
                score_text.text = "SCORE: " + score.ToString();
                time_text.text = "TIME: " + time.ToString();
            }
        }
    }


}
