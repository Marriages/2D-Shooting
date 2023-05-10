//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.InputSystem.EnhancedTouch;

public delegate void AbilityDelegate();

public struct Ability
{
    public string abilityName;
    public Sprite abilityImage;
    public AbilityDelegate abilityDelegate;
}


public class UIChoice : MonoBehaviour
{
    Image[] choiceOutline;
    Image[] choiceImage;
    TextMeshProUGUI[] choiceText;

    InputSystemController inputActions;
    int uiIndex = 0;
    int indexNum = 0;

    Ability[] abil;
    List<Ability> abilList;

    

    private void Awake()
    {
        inputActions = new InputSystemController();

        choiceOutline = new Image[transform.childCount];
        choiceImage = new Image[transform.childCount];
        choiceText = new TextMeshProUGUI[transform.childCount];

        indexNum = transform.childCount;
        uiIndex = 0;
        for (int i = 0; i < choiceOutline.Length; i++)
        {
            choiceOutline[i] = transform.GetChild(i).GetComponent<Image>();
            choiceImage[i] = transform.GetChild(i).GetChild(0).GetComponent<Image>();
            choiceText[i] = transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>();

            choiceText[i].text = null;

            if (i == 0)
                choiceOutline[i].color = Color.red;
            else
                choiceOutline[i].color = Color.white;
        }

        InitializeAbility();        //������ �ɷ�ġ �����ϱ�.

    }
    private void OnEnable()
    {
        
        InitializeUIChoice();

        /////////////////////////Player�� ����������, �߻������� ���ϰ� ���ƾ� ��./////////////////////////

        inputActions.UIChoice.Enable();
        inputActions.UIChoice.Left.performed += UILeftMove;
        inputActions.UIChoice.Right.performed += UIRightMove;
        inputActions.UIChoice.Decide.performed += UIDecide;
    }
    private void OnDisable()
    {
        inputActions.UIChoice.Decide.performed -= UIDecide;
        inputActions.UIChoice.Right.performed -= UIRightMove;
        inputActions.UIChoice.Left.performed -= UILeftMove;
        inputActions.UIChoice.Disable();

        /////////////////////////Player�� �ٽ� ���������� ������ ���ְ� �ؾ���./////////////////////////
    }
    void InitializeAbility()
    {
        abil = new Ability[5];
        abil[0].abilityName = "Damage x 1.5";
        abil[0].abilityImage = Resources.Load<Sprite>("Image/DamageUp");
        abil[0].abilityDelegate = AbilityDamage1dot5Up;
        //GameManager.Instance.AbilityBulletDouble;
        // �ٸ� Ŭ������ �Լ��� �ִ� ���� �Ұ����غ��δ�.  -> ���������� GameManager�� ������ �� �ִ� �Լ��� ���� �������.

        abil[1].abilityName = "Bullet Capacity x 1.5";
        abil[1].abilityImage = Resources.Load<Sprite>("Image/BulletCapacityUp");
        abil[1].abilityDelegate = AbilityBulletCapacityDouble;

        abil[2].abilityName = "Move Speed x 1.5";
        abil[2].abilityImage = Resources.Load<Sprite>("Image/MoveSpeedUp");
        abil[2].abilityDelegate = AbilityMoveSpeed1dot5up;

        abil[3].abilityName = "Bullet Speed x2";
        abil[3].abilityImage = Resources.Load<Sprite>("Image/BulletSpeedUp");
        abil[3].abilityDelegate = AbilityBulletSpeedDouble;

        abil[4].abilityName = "Double Bullet Fire";
        abil[4].abilityImage = Resources.Load<Sprite>("Image/BulletDouble");
        abil[4].abilityDelegate = AbilityBulletDouble;

        //������ ������� abil �迭�� ����Ʈ�� �ֱ�.
        abilList = new List<Ability>(abil);
        //Debug.Log("���� ��");
        //foreach(Ability ab in abilList)
        //    Debug.Log(ab.abilityName);

        abilList = ShuffleAbility(abilList);

        //Debug.Log("���� ��");
        //foreach (Ability ab in abilList)
        //    Debug.Log(ab.abilityName);

    }
    List<Ability> ShuffleAbility(List<Ability> abil)
    {
        //Fisher - Yates �˰��� ����Ͽ� �迭 ����
        int listCnt = abil.Count;
        Ability tempAbil;
        for (int i = listCnt - 1;i>0;i--)
        {
            int tempIndex = Random.Range(0, i + 1);
            tempAbil = abil[tempIndex];
            abil[tempIndex] = abil[i];
            abil[i] = tempAbil;
        }
        return abil;
    }
    void InitializeUIChoice()
    {
        // ������ �������� InitializeAbility �Ǵ� UiDecide���� ���� abilList�� 1,2,3��° ���� ������� ���� ��.
        for(int i=0;i< indexNum; i++)
        {
            if (abilList.Count>=3)
            {
                //������ Resource�� ���������, ���߿���.......Bundle�� ����غ����� ����!
                choiceImage[i].sprite = abilList[i].abilityImage;
                choiceText[i].text = abilList[i].abilityName;
            }
            else
            {
                GameManager.instance.NextStageReady();
            }
        }
    }

    private void UIDecide(InputAction.CallbackContext _)
    {
        //1,2,3,��° �� �� ���õ� ���� ����Ʈ���� �����ϰ�, ����Ʈ�� ���� ��.
        abilList[uiIndex].abilityDelegate();
        abilList.RemoveAt(uiIndex);
        abilList = ShuffleAbility(abilList);

        //���ӸŴ������� �� ���� �����ٰ� �����ֱ�.
        GameManager.instance.NextStageReady();
    }
    private void UILeftMove(InputAction.CallbackContext _)
    {
        MoveSelection(-1);
    }
    private void UIRightMove(InputAction.CallbackContext _)
    {
        MoveSelection(1);
    }
    void MoveSelection(int x)
    {
        choiceOutline[uiIndex].color = Color.white;

        uiIndex += x;
        if (uiIndex< 0)
            uiIndex = indexNum - 1;
        else if (uiIndex >= indexNum)
            uiIndex = 0;

        choiceOutline[uiIndex].color = Color.red;
    }


    //------------------Ability ����ü ���� GamaManager ���� �����Լ�-----------------------------
    public void AbilityDamage1dot5Up()  { 
        GameManager.instance.AbilityDamage1dot5Up();
    }
    public void AbilityBulletDouble()   {
        GameManager.instance.AbilityBulletDouble();
    }
    public void AbilityBulletCapacityDouble(){
        GameManager.instance.AbilityBulletCapacityDouble();
    }
    public void AbilityMoveSpeed1dot5up() {
        GameManager.instance.AbilityMoveSpeed1dot5up();
    }
    public void AbilityBulletSpeedDouble() {
        GameManager.instance.AbilityBulletSpeedDouble();
    }
    //------------------Ability ����ü ���� GamaManager ���� �����Լ�-----------------------------
}
