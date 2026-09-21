
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

    [SerializeField] private InputActionAsset actions;
    [SerializeField] private InputAction jump;
    [SerializeField] private float speed = 1f;
    private InputAction xAxis;
    [SerializeField] private float jumpForce = 350f;

    void Awake()
    {
        jump = actions.FindActionMap(ACTION_MAP).FindAction(JUMP_ACTION);
        xAxis = actions.FindActionMap(ACTION_MAP).FindAction(X_AXIS);

        jump.performed += ctx => { OnJump(ctx); };
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        GetComponent<Rigidbody>().AddForce(jumpForce * Vector3.up);
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
}
