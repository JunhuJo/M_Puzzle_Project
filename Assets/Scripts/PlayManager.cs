using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public Slider audio_Bar;
    //private AllStageManager allStageManager;
    [Header("Start_Page_Back")]
    [SerializeField] private Button start_Page_Back_Btn;
    [SerializeField] private Button start_Page_Back_Go_Btn;
    [SerializeField] private Button start_Page_Back_close_Btn;
    [SerializeField] private GameObject start_Recall_Window;
    [Header("Option")]
    [SerializeField] private Button option_Btn;
    [SerializeField] private Button option_close_Btn;
    [SerializeField] private GameObject option_Window;
    
    private void Start()
    {
        Set_Btn();
    }

    private void Set_Btn()
    {
        start_Page_Back_Btn.onClick.AddListener(start_Window_Active);
        start_Page_Back_close_Btn.onClick.AddListener(start_Window_Active);
        start_Page_Back_Go_Btn.onClick.AddListener(Start_Page_Go);

        option_Btn.onClick.AddListener(option_Active);
        option_close_Btn.onClick.AddListener(option_Active);
    }

    private void option_Active()
    {
        if (option_Window.gameObject.activeSelf)
        {
            option_Window.gameObject.SetActive(false);
        }
        else
        {
            option_Window.gameObject.SetActive(true);
        }
        
    }

    private void start_Window_Active()
    {
        if(start_Recall_Window.gameObject.activeSelf)
        {
            start_Recall_Window.gameObject.SetActive(false);
        }
        else 
        {
            start_Recall_Window.gameObject.SetActive(true);
        }
    }

    private void Start_Page_Go()
    {
        Debug.Log("Start∑Œ ¿Ãµø");
        GameManager.Instance.audio_Swich = true;
        SceneManager.LoadScene("Start");
    }

    //private void Reset_Stage()
    //{
    //    GameObject allgamemanager = GameObject.Find("Play_Manager");
    //    allStageManager = allgamemanager.GetComponent<AllStageManager>();
    //    allStageManager.stage_Num = 0;
    //}
}
