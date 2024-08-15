using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager: MonoBehaviour
{
    [SerializeField]
    private List<GameObject> checkpointBlocks; // Список checkpoint блоков

    public Text textCircle;
    public int nextCheckpointIndex = 0;
    public int completedCircles = 0;

    public Button button;

    private void Update()
    {
        textCircle.text = "ROUND: " + completedCircles;
    }

    public void CheckpointReached(GameObject checkpointBlock)
    {
        if (checkpointBlocks[nextCheckpointIndex] == checkpointBlock)
        {
            // Обновляем цвет блока
            checkpointBlock.GetComponent<Renderer>().material.color = Color.green;

            // Переходим к следующему checkpoint
            nextCheckpointIndex++;
            Debug.Log(nextCheckpointIndex);
        }
    }

    public void FinishLineReached(GameObject finishBlock)
    {
        // Проверяем, все ли checkpoint'ы были коснуты перед финишем
        if (nextCheckpointIndex == checkpointBlocks.Count)
        {
            //finishBlock.GetComponent<Collider>().isTrigger = false;
            finishBlock.GetComponent<Renderer>().material.color = Color.black;
            Debug.Log(finishBlock.name);
            Debug.Log("Круг завершен!");
            completedCircles++;
            StartCoroutine(timer(0.5f, finishBlock));
        }
    }

    private void ResetCheckpoints(GameObject finish)
    {
        foreach (GameObject block in checkpointBlocks)
        {
            // Сброс цветов на исходный
            block.GetComponent<Renderer>().material.color = Color.white;
        }
        finish.GetComponent<Renderer>().material.color = Color.red;

        // Обнуляем индекс для нового круга
        nextCheckpointIndex = 0;
    }

    IEnumerator timer(float time, GameObject block)
    {
        yield return new WaitForSeconds(time);
        ResetCheckpoints(block);
        //block.GetComponent<Collider>().isTrigger = true;
    }
}
