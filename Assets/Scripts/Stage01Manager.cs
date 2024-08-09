using UnityEngine;
using UnityEngine.UI;

public class Stage01Manager : MonoBehaviour
{
    [SerializeField] private Button light_Swich_Btn;
    [SerializeField] private GameObject[] light_obj;
    private Image back_Ground;
    private int count = 0;
    [SerializeField] private AllStageManager all_stages;
   

    private void OnEnable()
    {
        GameObject allStages = GameObject.Find("Stage_Field");
        AllStageManager all_Stages = GetComponent<AllStageManager>();
        all_stages = all_Stages;

        GameObject background = GameObject.Find("Back_Ground");
        Image back_ground = background.GetComponent<Image>();
        back_Ground = back_ground;

        light_Swich_Btn.onClick.AddListener(OnClick_Swich_Active);
    }

    private void OnClick_Swich_Active()
    { 
        if(back_Ground.color == Color.white)
        {
            back_Ground.color = Color.black;
        }
        else if(back_Ground.color == Color.black)
        {
            back_Ground.color = Color.white;
            light_obj[count].gameObject.SetActive(false);
            count++;
            if (count == light_obj.Length)
            {
                all_stages.stage_Clear = true;
                Debug.Log("1스테이지 클리어");
            }
        }
    }
}
