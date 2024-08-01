using UnityEngine;
using UnityEngine.UI;

public class Stage01 : MonoBehaviour
{
    [SerializeField] private PlayManager playManager;

    [Header("Stage01")]
    public GameObject stage01;
    [SerializeField] private Image back_Ground;
    [SerializeField] private Button onSwitch;
    [SerializeField] private Button back_Btn;
    [SerializeField] private GameObject[] lights;
    private int count = 0;

    private void Start()
    {
        //스테이지 1
        onSwitch.onClick.AddListener(OnClick_On_Light);
        //back_Btn.onClick.AddListener(OnClick_Back);
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
                stage01.gameObject.SetActive(false);
                playManager.Stages[1].SetActive(true);
            }
        }
    }
    #endregion
}
