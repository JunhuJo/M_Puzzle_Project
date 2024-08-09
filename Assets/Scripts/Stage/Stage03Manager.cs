using UnityEngine;
using UnityEngine.UI;

public class Stage03Manager : MonoBehaviour
{
    [SerializeField] private GameObject player_Obj;
    private RectTransform player_Obj_RectTransform;
    private float move = 40;
    [SerializeField] private RectTransform goal_Area;
    [SerializeField] private Button left_Btn;
    [SerializeField] private Button right_Btn;
    [SerializeField] private AllStageManager all_stages;

    private void OnEnable()
    {
        if (all_stages == null)
        {
            GameObject allmanager = GameObject.Find("Play_Manager");
            AllStageManager all_Stage_Manager = allmanager.GetComponent<AllStageManager>();
            all_stages = all_Stage_Manager;
        }

        player_Obj_RectTransform = player_Obj.GetComponent<RectTransform>();

        left_Btn.onClick.AddListener(OnClick_Left);
        right_Btn.onClick.AddListener(OnClick_Right);
    }

    private void Update()
    {
        Clear_Game();
    }

    private void Clear_Game()
    {
        if (goal_Area.anchoredPosition.x <= player_Obj_RectTransform.anchoredPosition.x)
        {
            all_stages.stage_Clear = true;
            Debug.Log("3스테이지 클리어");
        }
    }

    private void OnClick_Right()
    {
        Vector2 currentPosition_Right = player_Obj_RectTransform.anchoredPosition;
        player_Obj_RectTransform.anchoredPosition = new Vector2(currentPosition_Right.x + move, currentPosition_Right.y);
    }

    private void OnClick_Left()
    {
        Vector2 currentPosition_Left = player_Obj_RectTransform.anchoredPosition;
        player_Obj_RectTransform.anchoredPosition = new Vector2(currentPosition_Left.x - move, currentPosition_Left.y);
    }
}
