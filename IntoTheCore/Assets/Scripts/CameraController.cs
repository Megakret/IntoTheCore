
using UnityEngine;

public class CameraController : MonoCache
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float minUpRotation = -80f;
    [SerializeField] private float maxUpRotation = 80f;

    private float UpRotation;
    private bool camLock = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void OnUpdate()
    {
        if (camLock)
        {
            return;
        }
        float mouseHorizontal = Input.GetAxis("Mouse X") * mouseSensitivity; // Input
        float mouseVertical = Input.GetAxis("Mouse Y") * mouseSensitivity;

        UpRotation -= mouseVertical; // Поворот камеры вверх-вниз (подсчет)
        UpRotation = Mathf.Clamp(UpRotation, minUpRotation, maxUpRotation);

        cameraTransform.localRotation = Quaternion.Euler(UpRotation, 0, 0); //Отображение поворотов у игрока
        transform.Rotate(new Vector3(0, mouseHorizontal, 0));

    }
    public void DisableControl()
    {
        camLock = true;
    }
    public void EnableControl()
    {
        camLock = false;
    }
}
