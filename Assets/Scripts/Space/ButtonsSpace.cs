using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class ButtonsSpace : MonoBehaviour
{
    public void SelectLevel()
    {
        // �������� ��� �������, �� �������� ��� ����.
        string selectedButtonName = EventSystem.current.currentSelectedGameObject.name;

        // �������� ������������� ��� ������ � ����� �����.
        if (int.TryParse(selectedButtonName, out int sceneNumber))
        {
            // ��������� �����, ���� �������������� ������ �������.
            SceneManager.LoadScene(sceneNumber);
            Debug.Log("�������� �����: " + sceneNumber);
        }
        else
        {
            // ������� ��������� �� ������, ���� �������������� �� �������.
            Debug.LogError("������: �� ������� ������������� ��� ������ '" + selectedButtonName + "' � ����� �����.");
        }
    }
}
