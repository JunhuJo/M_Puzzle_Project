using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region 싱글톤
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 로드될 때 파괴되지 않도록 설정
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 이 객체를 파괴
        }
    }
    #endregion

    [SerializeField] private Slider _audio_Bar;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Set_Volume();
    }

    private void Set_Volume()
    {
        _audioSource.volume = _audio_Bar.value;
    }
}
