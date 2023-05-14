using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAtack : MonoBehaviour
{
    InputSystemController inputActions;
    GameObject fireFlash;
    Transform firePosition;
    public GameObject firePrefab;
    bool doubleMode = false;

    private void Awake()
    {
        inputActions = new InputSystemController();
        fireFlash = transform.GetChild(0).gameObject;
        fireFlash.SetActive(false);
        firePosition = transform.GetChild(1).transform;
    }
    private void OnEnable()
    {
        PlayerAtackInputConnect();
    }
    private void OnDisable()
    {
        PlayerAtackInputUnConnect();
    }
    public void PlayerAtackInputConnect()
    {
        inputActions.Player.Enable();
        inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Bomb.performed += OnBomb;
    }
    public void PlayerAtackInputUnConnect()
    {
        inputActions.Player.Bomb.performed -= OnBomb;
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Disable();
    }
    private void OnFire(InputAction.CallbackContext _)
    {
        if(doubleMode==false)
        {
            PlayerBullet obj = BulletPool.instance.GetObject();
            if(obj != null )
            {
                obj.transform.position = firePosition.position;
                StartCoroutine(FireFlash());
            }
            else
            {
                // 틱틱 소리가 나게해서 효과음 주기
            }
        }
        else
        {
            PlayerBullet obj1 = BulletPool.instance.GetObject();
            PlayerBullet obj2 = BulletPool.instance.GetObject();

            if (obj1 != null && obj2 !=null)
            {
                obj1.transform.position = firePosition.position + Vector3.up*0.5f;
                obj2.transform.position = firePosition.position + Vector3.down * 0.5f + Vector3.left * 0.1f;
                StartCoroutine(FireFlash());
            }
            else
            {
                // 틱틱 소리가 나게해서 효과음 주기
            }

        }
    }
    IEnumerator FireFlash()
    {
        fireFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        fireFlash.SetActive(false);
    }
    private void OnBomb(InputAction.CallbackContext _)
    {

    }
    public void AbilityBulletDouble()
    {
        doubleMode = true;
    }
}
