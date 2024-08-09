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

    public bool audio_Swich = false;
    
    [SerializeField] private Slider main_Audio_Bar;
    
    private AudioSource _audioSource;
   

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Set_Start_Volume();
    }

    private void Update()
    {
        Set_Volume();
    }

    //게임 시작 초기 볼륨 세팅
    private void Set_Start_Volume()
    {
        GameObject startmanager = GameObject.Find("Start_Manager");
        StartManager start_Manager = startmanager.GetComponent<StartManager>();
        main_Audio_Bar = start_Manager._audio_Bar;
    }

    private void Set_Volume()
    {
        _audioSource.volume = main_Audio_Bar.value;

        if (SceneManager.GetActiveScene().name == "Game")
        {
            GameObject playManager = GameObject.Find("Play_Manager");
            PlayManager play_manager = playManager.GetComponent<PlayManager>();
            play_manager.audio_Bar.value = _audioSource.volume;
            main_Audio_Bar = play_manager.audio_Bar;
        }
        else if (SceneManager.GetActiveScene().name == "Start" && audio_Swich)
        {
            Debug.Log("볼륨 전환");
            GameObject startManager = GameObject.Find("Start_Manager");
            StartManager start_Manager = startManager.GetComponent<StartManager>();
            start_Manager._audio_Bar.value = _audioSource.volume;
            main_Audio_Bar = start_Manager._audio_Bar;
            audio_Swich = false;
        }
    }
}
