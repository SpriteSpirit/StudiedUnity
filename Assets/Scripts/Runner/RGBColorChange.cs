using UnityEngine;

public class RGBColorChange : MonoBehaviour
{
    float redSpeed = 1f; // Скорость изменения красного цвета.
    float greenSpeed = 1f; // Скорость изменения зеленого цвета.
    float blueSpeed = 1f; // Скорость изменения синего цвета.

    private Camera camera; // Ссылка на камеру.

    private void Start()
    {
        camera = GetComponent<Camera>(); // Получаем компонент Camera из объекта.
    }

    private void Update()
    {
        // Изменяем компоненты RGB цвета фона.
        float red = Mathf.Sin(Time.time * redSpeed) / 2f + 0.5f;
        float green = Mathf.Sin(Time.time * greenSpeed + Mathf.PI * 2f / 3f) / 2f + 0.5f;
        float blue = Mathf.Sin(Time.time * blueSpeed + Mathf.PI * 4f / 3f) / 2f + 0.5f;

        // Устанавливаем новый цвет фона.
        camera.backgroundColor = new Color(red, green, blue);

        // Изменяем скорость изменения компонентов RGB цвета фона.
        redSpeed += Input.GetAxisRaw("Vertical");
        greenSpeed += Input.GetAxisRaw("Vertical");
        blueSpeed += Input.GetAxisRaw("Vertical");
    }
}