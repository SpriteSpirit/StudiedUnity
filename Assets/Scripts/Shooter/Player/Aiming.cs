using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aiming : MonoBehaviour
{
    [Header("Camera Setting")]
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Camera aimCamera;
    [SerializeField]
    private Image image;
    [SerializeField]
    private float scale;
    private Vector3 currentSize;


    private void Start()
    {
        mainCamera = Camera.main;
        aimCamera = GameObject.FindGameObjectWithTag("AimCamera").GetComponent<Camera>();
        image = Transform.FindObjectOfType<Image>();

        currentSize = image.transform.localScale;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mainCamera.enabled = false;
            aimCamera.enabled = true;

            ChangeImageSize(aimCamera.enabled);
            Debug.Log(currentSize);
        }

        if (Input.GetMouseButtonUp(1))
        {
            mainCamera.enabled = true;
            aimCamera.enabled = false;

            ChangeImageSize(aimCamera.enabled);
            Debug.Log(currentSize);
        }
    }

    void ChangeImageSize(bool value)
    {
        if (value)
        {
            image.transform.localScale = new Vector3(currentSize.x * scale, currentSize.y * scale, currentSize.z);
            Debug.Log(currentSize);
        }
        else
        {
            image.transform.localScale = currentSize;
        }

    }
}
