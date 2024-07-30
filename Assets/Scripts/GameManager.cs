using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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

    [Header("Start")]
    [SerializeField] private Button game_Start;
    [SerializeField] private Button game_Quit;
    [SerializeField] private Button option;

    [Header("Option")]
    [SerializeField] private Button back_Btn;
    [SerializeField] private GameObject option_window;

    private void Start()
    {
        game_Start.onClick.AddListener(OnClick_Game_Start);

        option.onClick.AddListener(OnClick_Option);
        back_Btn.onClick.AddListener(OnClick_Option);

        game_Quit.onClick.AddListener(OnClick_Game_Quit);
    }

    private void Update()
    {

        Game_Play();
    }

    private void Game_Play()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            Debug.Log("Game_Scene이다");
        }
    }

    public void OnClick_Game_Start()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClick_Option()
    {
        if (!option.gameObject.activeSelf)
        {
            option_window.gameObject.SetActive(true);
        }
        else 
        {
            option_window.gameObject.SetActive(false);
        }
        
    }

    public void OnClick_Option_Back()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnClick_Game_Quit()
    {
        Debug.Log("Game_Quit");
        Application.Quit(); 
    }
}
