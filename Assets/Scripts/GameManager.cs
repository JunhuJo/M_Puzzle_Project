using UnityEngine;
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
    [SerializeField] private PlayManager playManager;

    [Header("Start")]
    [SerializeField] private GameObject start_Page;
    [SerializeField] private Button game_Start;
    [SerializeField] private Button game_Quit;
    [SerializeField] private Button option;

    [Header("Option")]
    [SerializeField] private Button back_Btn;
    [SerializeField] private GameObject option_window;


    public void OnClick_Game_Start()
    {
        start_Page.gameObject.SetActive(false);
        playManager.Stages[0].gameObject.SetActive(true);
    }

    public void OnClick_Option()
    {
       option_window.gameObject.SetActive(true);
    }

    public void OnClick_Option_Back()
    {
       option_window.gameObject.SetActive(false);
    }

    public void OnClick_Game_Quit()
    {
        Debug.Log("Game_Quit");
        Application.Quit(); 
    }
}
