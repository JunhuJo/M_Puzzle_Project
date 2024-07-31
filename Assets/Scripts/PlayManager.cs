using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public GameManager gameManager;

    [Header("Stage01")]
    [SerializeField] private Image back_Ground;
    [SerializeField] private Button onSwitch;
    [SerializeField] private Button back_Btn;
    [SerializeField] private GameObject[] lights;
    private int count = 0;

    [Header("Stage02")]
    [SerializeField] private GameObject stage02_Back_Ground;
    [SerializeField] private GameObject map;
    [SerializeField] private Button down_Btn;


    private void Start()
    {
        //스테이지 1
        onSwitch.onClick.AddListener(OnClick_On_Light);
        //back_Btn.onClick.AddListener(OnClick_Back);

        //스테이지 2
        down_Btn.onClick.AddListener(Move_map);
    }


    #region 1 Stage
    public void OnClick_On_Light()
    {
        
        // 이미지 색상을 흰색에서 검은색으로 변경
        if (back_Ground.color == Color.white)
        {
            back_Ground.color = Color.black;
        }
        else if (back_Ground.color == Color.black)
        {
            back_Ground.color = Color.white;
            lights[count].gameObject.SetActive(false);
            count++;

            if (count == lights.Length)
            {
                stage02_Back_Ground.gameObject.SetActive(true);
            }
        }
    }
    #endregion

    #region 2 Stage
    public void Move_map()
    {
        map.transform.Translate(Vector2.down * 20);
    }
    #endregion
}
