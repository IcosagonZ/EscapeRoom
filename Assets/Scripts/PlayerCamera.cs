using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    public Transform playerCamera;

    private float playerRotation = 0f;

    void Start()
    {
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerRotation -= mouseY;
        playerRotation = Mathf.Clamp(playerRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(playerRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
