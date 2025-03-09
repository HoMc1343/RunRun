using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector3 spawnPosition = Vector3.zero; // 스폰 좌표
    public string lastPortalTag = ""; // 마지막 사용 포탈

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePortalData(Vector3 position, string portalTag)
    {
        spawnPosition = position;
        lastPortalTag = portalTag;
    }
}