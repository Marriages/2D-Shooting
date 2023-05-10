using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource audioBackground;       //GetComponent�� ���ϱ� ���� SerializeField�� ������.
    [SerializeField] AudioSource audioEffect;           //GetComponent�� ���ϱ� ���� SerializeField�� ������.

    float backSoundSize=0.8f;
    float effectSoundSize = 0.5f;

    public AudioClip background;
    public AudioClip playerHit;
    public AudioClip playdrDie;
    public AudioClip playerAtack;
    public AudioClip playerCoin;
    public AudioClip EnemyHit;
    public AudioClip EnemyDie;
    
    private void Awake()
    {
        instance = this;
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
        audioBackground.volume = backSoundSize;
        audioBackground.clip = background;

        audioEffect.volume = effectSoundSize;
        audioEffect.clip = null;
    }

    public void AudioPlayerHit()
    {
        audioEffect.PlayOneShot(playerHit);
    }
    public void AudioPlayerDie()
    {
        audioEffect.PlayOneShot(playerHit);
    }
    public void AudioPlayerCoin()
    {
        audioEffect.PlayOneShot(playerCoin);
    }
    public void AudioPlayerAtack()
    {
        audioEffect.PlayOneShot(playerAtack);
    }
    public void AudioEnemyHit()
    {
        audioEffect.PlayOneShot(EnemyHit);
    }
    public void AudioEnemyDie()
    {
        audioEffect.PlayOneShot(EnemyDie);
    }
}
