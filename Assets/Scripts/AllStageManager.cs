using System.Collections.Generic;
using UnityEngine;

public class AllStageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] stage_Prefabs;
    [SerializeField] private GameObject stage_Field;
    public bool stage_Clear = false;
    public int stage_Num = 0;
    private Queue<GameObject> stages = new Queue<GameObject>();
    private GameObject _stages;

    private void Start()
    {
        Stage_Start();
    }

    private void Update()
    {
        Next_Stage();
    }

    private void Stage_Start()
    {
        _stages = Instantiate(stage_Prefabs[stage_Num], stage_Field.transform);
    }
    
    private void Next_Stage()
    {
        if (stage_Clear)
        {
            stage_Clear = false;
            Destroy(_stages.gameObject);
            stage_Num++;

            Debug.Log("다음 스테이지로");
            _stages = Instantiate(stage_Prefabs[stage_Num], stage_Field.transform);
        }
    }
}
