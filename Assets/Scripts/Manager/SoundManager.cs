using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource sfxSource; // 효과음 재생기
    public AudioSource bgmSource; // BGM 재생기
    public AudioClip[] sfxClips;  // 효과음 목록

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (sfxSource == null)
            {
                sfxSource = gameObject.AddComponent<AudioSource>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(int index, float volume = 1f)
    {
        if (sfxSource == null)
        {
            return;
        }

        if (sfxClips == null || sfxClips.Length == 0)
        {
            return;
        }

        if (index < 0 || index >= sfxClips.Length || sfxClips[index] == null)
        {
            return;
        }

        sfxSource.PlayOneShot(sfxClips[index], volume);
    }
}
