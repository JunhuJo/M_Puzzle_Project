using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region �̱���
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
            DontDestroyOnLoad(gameObject); // ���� �ε�� �� �ı����� �ʵ��� ����
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� �� ��ü�� �ı�
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
