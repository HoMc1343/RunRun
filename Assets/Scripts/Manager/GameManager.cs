using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector3 spawnPosition;

    private Vector3 firstPosition = new Vector3(35, 1, -11);
    private Vector3 lastPosition = new Vector3(-90, 1, -90);

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

    public void SetDefaultSpawnPosition(string sceneName)
    {
        if (sceneName == "FirstScene")
        {
            spawnPosition = firstPosition;
        }
        else if (sceneName == "LastScene")
        {
            spawnPosition = lastPosition;
        }
    }

    public void SavePortalData(Vector3 position, string portalTag)
    {
        spawnPosition = position;
    }
}