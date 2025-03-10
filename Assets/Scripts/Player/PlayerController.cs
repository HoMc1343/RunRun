using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpPower;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer; // 카메라 위치
    public Transform thirdCamera; // 3인칭 카메라
    public Camera mainCamera; // 현재 활성화된 카메라
    private bool firstCamera = true; // 1인칭 카메라
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;
    public Action inventory;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SwitchFirstView();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }

        if (!firstCamera)
        {
            AdjustThirdCamera();
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            SoundManager.Instance.PlaySound(3);
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for(int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
            ToggleCursor();
        }
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }

    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }

    public void OnSwitchView(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (context.control.name == "1")
            {
                SwitchFirstView();
            }
            else if (context.control.name == "2")
            {
                SwitchThirdView();
            }
        }
    }

    private void SwitchFirstView()
    {
        firstCamera = true;
        mainCamera.transform.SetParent(cameraContainer);
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localRotation = Quaternion.identity;
    }

    private void SwitchThirdView()
    {
        firstCamera = false;
        mainCamera.transform.SetParent(thirdCamera);
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localRotation = Quaternion.identity;
    }

    void AdjustThirdCamera()
    {
        Vector3 desiredCameraPos = thirdCamera.position; // 기본 위치
        Vector3 direction = (thirdCamera.position - transform.position).normalized; // 방향 계산
        float distance = Vector3.Distance(transform.position, thirdCamera.position); // 거리 계산

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, distance, groundLayerMask))
        {
            // 벽이 감지되면 카메라를 벽 앞으로 이동
            mainCamera.transform.position = hit.point + (direction * 0.2f);
        }
        else
        {
            // 충돌이 없으면 원래 위치로 복귀
            mainCamera.transform.position = desiredCameraPos;
        }
    }
}