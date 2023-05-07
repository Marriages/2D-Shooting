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

    private void Awake()
    {
        inputActions = new InputSystemController();
        fireFlash = transform.GetChild(0).gameObject;
        fireFlash.SetActive(false);
        firePosition = transform.GetChild(1).transform;
    }
    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Bomb.performed += OnBomb;
    }
    private void OnDisable()
    {
        inputActions.Player.Bomb.performed -= OnBomb;
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Disable();
    }
    private void OnFire(InputAction.CallbackContext _)
    {
        PlayerBullet obj = BulletPool.instance.GetObject();
        if(obj != null )
        {
            obj.transform.position = firePosition.position;
            StartCoroutine(FireFlash());
        }
        else
        {
            Debug.Log("총알이 없어요...");
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
}
