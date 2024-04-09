using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    [SerializeField]
    private List<GameObject> checkpointBlocks; // ������ checkpoint ������

    public Text textCircle;
    public int nextCheckpointIndex = 0;
    public int completedCircles = 0;


    private void Update()
    {
        textCircle.text = "ROUND: " + completedCircles;
    }

    public void CheckpointReached(GameObject checkpointBlock)
    {
        if (checkpointBlocks[nextCheckpointIndex] == checkpointBlock)
        {
            // ��������� ���� �����
            checkpointBlock.GetComponent<Renderer>().material.color = Color.green;

            // ��������� � ���������� checkpoint'�
            nextCheckpointIndex++;
            Debug.Log(nextCheckpointIndex);
        }
    }

    public void FinishLineReached(GameObject finishBlock)
    {
        // ���������, ��� �� checkpoint'� ���� ������� ����� �������
        if (nextCheckpointIndex == checkpointBlocks.Count)
        {
            finishBlock.GetComponent<Collider>().isTrigger = false;
            finishBlock.GetComponent<Renderer>().material.color = Color.black;
            Debug.Log(finishBlock.name);
            Debug.Log("���� ��������!");
            completedCircles++;
            StartCoroutine(timer(0.5f, finishBlock));
        }
    }

    private void ResetCheckpoints(GameObject finish)
    {
        foreach (GameObject block in checkpointBlocks)
        {
            // ����� ������ �� ��������
            block.GetComponent<Renderer>().material.color = Color.white;
        }
        finish.GetComponent<Renderer>().material.color = Color.red;

        // �������� ������ ��� ������ �����
        nextCheckpointIndex = 0;
    }

    IEnumerator timer(float time, GameObject block)
    {
        yield return new WaitForSeconds(time);
        ResetCheckpoints(block);
        block.GetComponent<Collider>().isTrigger = true;
    }
}
