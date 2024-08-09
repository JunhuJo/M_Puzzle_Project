using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    private GameManager _gameManager;

    //Audio_Bar
    public Slider _audio_Bar;

    //Start
    private Button _start_Btn;

    //Option
    private Button _option_Btn;
    [SerializeField] private GameObject _option_window;

    //Quit
    private Button _quit_Btn;

    private void Start()
    {
        Set_Btn();
    }

    private void Set_Btn()
    {
        Debug.Log("Set_Btn");
        GameObject manager = GameObject.Find("Game_Manager");
        _gameManager = manager.GetComponent<GameManager>();

        //start
        GameObject start_Btn = GameObject.Find("Start_Btn");
        _start_Btn = start_Btn.GetComponent<Button>();
        _start_Btn.onClick.AddListener(OnClick_Game_Start);
        //option
        GameObject option_Btn = GameObject.Find("Option_Btn");
        _option_Btn = option_Btn.GetComponent<Button>();
        _option_Btn.onClick.AddListener(OnClick_Option);
        //quit
        GameObject quit_Btn = GameObject.Find("Quit_Btn");
        _quit_Btn = quit_Btn.GetComponent<Button>();
        _quit_Btn.onClick.AddListener(OnClick_Game_Quit);
    }

    private void OnClick_Game_Start()
    {
        Debug.Log("Start_Btn");
        SceneManager.LoadScene("Game");
    }

    private void OnClick_Option()
    {
        Debug.Log("Option_Btn");
        
        if (_option_window != null)
        {
            if (_option_window.activeSelf)
            {
                _option_window.gameObject.SetActive(false);
            }
            else
            {
                _option_window.gameObject.SetActive(true);
            }
        }
    }

    private void OnClick_Game_Quit()
    {
        Debug.Log("Game_Quit");
        Application.Quit();
    }
}
