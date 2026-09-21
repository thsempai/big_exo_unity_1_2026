
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    private const string ACTION_MAP = "CubeActionsMap";
    private const string JUMP_ACTION = "Jump";
    private const string X_AXIS = "XAxis";

    private const float CHECK_GROUND_LENGTH = 0.55f;

    [SerializeField] private InputActionAsset actions;
    [SerializeField] private InputAction jump;
    [SerializeField] private float speed = 1f;
    private InputAction xAxis;
    [SerializeField] private float jumpForce = 350f;

    private Vector3 startPosition;

    void Awake()
    {
        jump = actions.FindActionMap(ACTION_MAP).FindAction(JUMP_ACTION);
        xAxis = actions.FindActionMap(ACTION_MAP).FindAction(X_AXIS);

        jump.performed += ctx => { OnJump(ctx); };
        startPosition = transform.position;
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (IsGrounded())
        {
            GetComponent<Rigidbody>().AddForce(jumpForce * Vector3.up);
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new(transform.position, Vector3.down);
        return Physics.Raycast(ray, CHECK_GROUND_LENGTH * transform.localScale.y);
    }

    void OnEnable()
    {
        actions.FindActionMap(ACTION_MAP).Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap(ACTION_MAP).Disable();
    }

    void Update()
    {
        MoveX();
        AutoForward();
    }

    private void AutoForward()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * xMove * transform.right;

    }

    public void Respawn()
    {
        transform.position = startPosition;
    }

    public void Stop()
    {
        enabled = false;
    }
}
