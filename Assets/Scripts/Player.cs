using UnityEngine;
using UnityEngine.InputSystem;

using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    public float gravity = -9.81f;

    public InputActionAsset inputActionAsset;
    public Camera playerCamera;

    private Rigidbody playerRigidBody;
    private Transform playerCameraTransform;

    private InputAction moveAction;
    private Vector2 moveVector;

    private Vector3 cameraForward;
    private Vector3 cameraRight;

    private Vector3 playerDirection;
    private Vector3 playerVelocity;

    void Awake()
    {
        moveAction = inputActionAsset.FindActionMap("Player").FindAction("Move");
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Capture cursor
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        moveAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
    }

    void Update()
    {
        moveVector = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        playerCameraTransform = playerCamera.transform;

        cameraForward = playerCameraTransform.forward;
        cameraRight = playerCameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        playerDirection = (moveVector.x * cameraRight + moveVector.y * cameraForward).normalized;

        playerVelocity = playerDirection * moveSpeed;
        playerVelocity.y = gravity;

        playerRigidBody.linearVelocity = playerVelocity;
    }
}
