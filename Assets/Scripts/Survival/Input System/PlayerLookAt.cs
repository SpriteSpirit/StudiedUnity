using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    private float rotateSpeed = 0.3f; // Уменьшил скорость для более естественного ощущения
    private Vector2 m_Look;
    private Vector2 m_Rotation;

    private InputAction lookAction;

    private void Awake()
    {
        // Получаем ссылку на действие Look из Input Actions
        var inputActionAsset = Resources.Load<InputActionAsset>("YourInputActionAssetName");
        lookAction = inputActionAsset.FindAction("Player/Look");
    }

    private void OnEnable()
    {
        lookAction.Enable();
        lookAction.performed += OnLook;
        lookAction.canceled += OnLook;
    }

    private void OnDisable()
    {
        lookAction.performed -= OnLook;
        lookAction.canceled -= OnLook;
        lookAction.Disable();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Look(m_Look);
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;
        var scaledRotateSpeed = rotateSpeed;
        m_Rotation.y += rotate.x * scaledRotateSpeed;
        m_Rotation.x = Mathf.Clamp(m_Rotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        transform.localEulerAngles = new Vector3(m_Rotation.x, m_Rotation.y, 0);
    }
}