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
        // Получаем имя объекта, по которому был клик.
        string selectedButtonName = EventSystem.current.currentSelectedGameObject.name;

        // Пытаемся преобразовать имя кнопки в номер сцены.
        if (int.TryParse(selectedButtonName, out int sceneNumber))
        {
            // Загружаем сцену, если преобразование прошло успешно.
            SceneManager.LoadScene(sceneNumber);
            Debug.Log("Загрузка сцены: " + sceneNumber);
        }
        else
        {
            // Выводим сообщение об ошибке, если преобразование не удалось.
            Debug.LogError("Ошибка: Не удалось преобразовать имя кнопки '" + selectedButtonName + "' в номер сцены.");
        }
    }
}
