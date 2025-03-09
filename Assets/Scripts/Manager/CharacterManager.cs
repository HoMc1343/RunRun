using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance;
    public static CharacterManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CharacterManager");
                _instance = obj.AddComponent<CharacterManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private Player _player;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<Player>();
            if (_player == null)
            {
                GameObject playerObj = new GameObject("Player");
                _player = playerObj.AddComponent<Player>();
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_player != null)
        {
            _player.transform.position = GameManager.Instance.spawnPosition;
        }
    }
}