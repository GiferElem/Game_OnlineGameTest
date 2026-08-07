using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_PlayerMove : MonoBehaviour
{
    private InputSystem inputActions;
    public float moveSpeed;
    public float rotSpeed;

    private void Awake()
    {
        inputActions = new InputSystem();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        Vector2 moveInput = inputActions.GamePlay.Move.ReadValue<Vector2>();
        Vector3 dir = new Vector3(moveInput.x, 0, moveInput.y);
        dir.Normalize();
        Vector3 movement = dir * moveSpeed * Time.deltaTime;

        transform.position += movement;
        if (dir.magnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation
                , targetRot, rotSpeed * Time.deltaTime);
        }
    }
}
