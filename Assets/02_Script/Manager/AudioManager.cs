using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource audioBackground;       //GetComponent를 안하기 위해 SerializeField로 선언함.
    [SerializeField] private AudioSource audioEffect;           //GetComponent를 안하기 위해 SerializeField로 선언함.
    [SerializeField] private AudioSource audioAtack;

    [SerializeField] float backSoundSize=0.8f;
    [SerializeField] float effectSoundSize = 0.6f;
    [SerializeField] float atackSoundSize = 0.4f;

    public AudioClip background;
    public AudioClip playerHit;
    public AudioClip playerDie;
    public AudioClip playerAtack;       // 소리가 큼
    public AudioClip playerCoin;        // 소리가 좀 작음
    public AudioClip EnemyHit;
    public AudioClip EnemyDie;          // 거의 안들림
    public AudioClip GameOver;
    
    private void Awake()
    {
        instance = this;
        //audioBackground = GetComponents<AudioSource>()[0];        //변수를 Serialize로 선언했기때문에 Awake에서 찾을 필요 없음.
        //audioEffect = GetComponents<AudioSource>()[1];
    }

    private void OnEnable()
    {
        AudioInitializeSetting();
    }
    //오디오 초기세팅
    void AudioInitializeSetting()
    { 
        audioBackground.volume = backSoundSize;
        audioBackground.clip = background;
        audioBackground.loop = true;
        audioBackground.Play();

        audioEffect.volume = effectSoundSize;
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
        //Debug.Log("GameOver 음악 재생");
        yield return new WaitForSeconds(playerDie.length);
        audioBackground.clip = GameOver;
        audioBackground.Play();
        
    }
}
