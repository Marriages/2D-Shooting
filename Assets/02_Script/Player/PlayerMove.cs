using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    InputSystemController inputActions;
    Animator anim;
    Rigidbody2D rigid;
    Vector2 inputDir;
    float dirY=0f;
    public float moveSpeed;
    public Action PlayerHit;

    private void Awake()
    {
        inputActions = new InputSystemController();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.UDLR.performed += OnMove;
        inputActions.Player.UDLR.canceled += OnMove;
    }
    private void OnDisable()
    {
        inputActions.Player.UDLR.canceled -= OnMove;
        inputActions.Player.UDLR.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + moveSpeed * Time.fixedDeltaTime * inputDir);
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        inputDir = (context.ReadValue<Vector2>()).normalized;
        dirY = inputDir.y;
        anim.SetFloat("PosY", dirY);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player : Heart Minus");
            PlayerHit?.Invoke();
        }
    }
}
