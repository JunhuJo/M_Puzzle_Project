using UnityEngine;
using UnityEngine.UI;

public class Stage02Manager : MonoBehaviour
{
    [SerializeField] private Button down_Btn;
    [SerializeField] private GameObject down_Obj;
    [SerializeField] private AllStageManager all_stages;
    private RectTransform down_Obj_rectTransform;
    private RectTransform area_Obj_rectTransform;
    private float down = 40;

    private void OnEnable()
    {
        if (all_stages == null)
        {
            GameObject allmanager = GameObject.Find("Play_Manager");
            AllStageManager all_Stage_Manager = allmanager.GetComponent<AllStageManager>();
            all_stages = all_Stage_Manager;
        }

        GameObject areaobj = GameObject.Find("Result_Area");
        area_Obj_rectTransform = areaobj.GetComponent<RectTransform>();

        down_Obj_rectTransform = down_Obj.GetComponent<RectTransform>();
        down_Btn.onClick.AddListener(OnClick_Obj_Down);
    }

    private void Update()
    {
        Clear_Game();   
    }

    private void OnClick_Obj_Down()
    {
        // 현재 anchoredPosition 값을 가져옵니다.
        Vector2 currentPosition = down_Obj_rectTransform.anchoredPosition;

        // Y축 방향으로 'down'만큼 아래로 이동시킵니다.
        down_Obj_rectTransform.anchoredPosition = new Vector2(currentPosition.x, currentPosition.y - down);
    }

    private void Clear_Game()
    {
        if (down_Obj_rectTransform.anchoredPosition.y <= area_Obj_rectTransform.anchoredPosition.y)
        {
            all_stages.stage_Clear = true;
            Debug.Log("2스테이지 클리어");
        }
    }
}
