using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    InputSystemController inputActions;
    Animator anim;
    Rigidbody2D rigid;
    Collider2D col;
    Vector2 inputDir;
    float dirY=0f;
    public float moveSpeed;
    public Action PlayerHit;
    public Action PlayerDie;
    Vector3 firstPosition = new(-7, 0, 0);

    public GameObject playerDieEffect;

    private void Awake()
    {
        inputActions = new InputSystemController();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }
    private void OnEnable()
    {
        col.enabled = true;
        PlayerMoveInputConnect();
    }
    private void OnDisable()
    {
        PlayerMoveInputUnConnect();
    }
    public void PlayerMoveInputConnect()
    {
        inputDir = Vector2.zero;
        rigid.velocity = Vector2.zero;
        inputActions.Player.Enable();
        inputActions.Player.UDLR.performed += OnMove;
        inputActions.Player.UDLR.canceled += OnMove;
    }
    public void PlayerMoveInputUnConnect()
    {
        inputDir = Vector2.zero;
        rigid.velocity = Vector2.zero;
        inputActions.Player.UDLR.canceled -= OnMove;
        inputActions.Player.UDLR.performed -= OnMove;
        inputActions.Player.Disable();
    }
    public void PlayerMoveReset()
    {
        inputDir = Vector2.zero;
        transform.position = firstPosition;
        rigid.velocity = Vector2.zero;
    }
    public void PlayerDieEffect()
    {
        inputDir = Vector2.zero;
        rigid.velocity = Vector2.zero;
        col.enabled = false;
        PlayerMoveInputUnConnect();
        StartCoroutine(PlayerDieEffectCoroutine());
    }
    IEnumerator PlayerDieEffectCoroutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.2f);

        for(int i=0;i<10;i++)
        {
            GameObject obj = Instantiate(playerDieEffect);
            obj.transform.position = transform.position + UnityEngine.Random.insideUnitSphere;
            AudioManager.instance.AudioEnemyDie();      //EnemyDie를 쓰는이유는.... 그 소리를 쓰고싶어서 ! ㅠ ㅠ
            yield return waitTime;
        }
        PlayerDie?.Invoke();
        gameObject.SetActive(false);
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
            //Debug.Log("Player : Heart Minus");
            AudioManager.instance.AudioPlayerHit();
            PlayerHit?.Invoke();
        }
    }
    public void AbilityMoveSpeed1dot5up()
    {
        moveSpeed *= 1.5f;
    }
}
