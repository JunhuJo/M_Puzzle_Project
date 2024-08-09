using UnityEngine;
using UnityEngine.UI;

public class Stage01Manager : MonoBehaviour
{
    [Header("Stage01_Seting")]
    [SerializeField] private Button light_Swich_Btn;
    [SerializeField] private GameObject[] light_obj;
    [SerializeField] private AllStageManager all_stages;

    private Image back_Ground;
    private int count = 0;
    
    private void OnEnable()
    {
        if (all_stages == null)
        {
            GameObject allmanager = GameObject.Find("Play_Manager");
            AllStageManager all_Stage_Manager = allmanager.GetComponent<AllStageManager>();
            all_stages = all_Stage_Manager;
        }

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
