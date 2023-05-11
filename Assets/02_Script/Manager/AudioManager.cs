using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource audioBackground;       //GetComponent�� ���ϱ� ���� SerializeField�� ������.
    [SerializeField] private AudioSource audioEffect;           //GetComponent�� ���ϱ� ���� SerializeField�� ������.
    [SerializeField] private AudioSource audioAtack;

    float backSoundSize=0.8f;
    float effectSoundSize = 0.6f;
    [SerializeField] float atackSoundSize = 0.4f;

    public float BackSoundSize
    {
        get => backSoundSize;
        set
        {
            if (value < 0)
                backSoundSize = 0f;
            else if (value > 1)
                backSoundSize = 1f;
            else
                backSoundSize = value;

            audioBackground.volume = BackSoundSize;
        }
    }
    public float EffectSoundSize
    {
        get => effectSoundSize;
        set
        {
            if (value < 0)
                effectSoundSize = 0f;
            else if(value>1)
                effectSoundSize = 1f;
            else
                effectSoundSize = value;

            audioEffect.volume = EffectSoundSize;
        }
    }


    public AudioClip background;
    public AudioClip playerHit;
    public AudioClip playerDie;
    public AudioClip playerAtack;       // �Ҹ��� ŭ
    public AudioClip playerCoin;        // �Ҹ��� �� ����
    public AudioClip EnemyHit;
    public AudioClip EnemyDie;          // ���� �ȵ鸲
    public AudioClip GameOver;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //audioBackground = GetComponents<AudioSource>()[0];        //������ Serialize�� �����߱⶧���� Awake���� ã�� �ʿ� ����.
        //audioEffect = GetComponents<AudioSource>()[1];
    }

    private void OnEnable()
    {
        AudioInitializeSetting();
    }
    //����� �ʱ⼼��
    void AudioInitializeSetting()
    { 
        audioBackground.volume = BackSoundSize;
        audioBackground.clip = background;
        audioBackground.loop = true;
        audioBackground.Play();

        audioEffect.volume = EffectSoundSize;
        audioBackground.loop = false;
        audioEffect.clip = null;

        audioAtack.volume = atackSoundSize;
        audioAtack.clip = playerAtack;
        audioAtack.loop = false;
        
    }
    public void AudioBackOff()
    {
        audioBackground.Stop();
    }

    public void AudioPlayerHit()
    {
        audioEffect.PlayOneShot(playerHit);
    }
    public void AudioPlayerCoin()
    {
        audioEffect.PlayOneShot(playerCoin);
    }
    public void AudioPlayerAtack()
    {
        audioAtack.Play();
    }
    public void AudioEnemyHit()
    {
        audioEffect.PlayOneShot(EnemyHit);
    }
    public void AudioEnemyDie()
    {
        audioEffect.PlayOneShot(EnemyDie);
    }
    public void AudioPlayerDie()
    {
        audioEffect.PlayOneShot(playerDie);
        StartCoroutine(AudioGameOver());

    }
    IEnumerator AudioGameOver()
    {
        //Debug.Log("GameOver ���� ���");
        yield return new WaitForSeconds(playerDie.length);
        audioBackground.clip = GameOver;
        audioBackground.Play();
        
    }

    public void BackgroundSoundSizeChange(float val)
    {
        BackSoundSize = val;
    }
    public void EffectSoundSizeChange(float val)
    {
        EffectSoundSize = val;
    }
}
