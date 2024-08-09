using System.Collections.Generic;
using UnityEngine;

public class AllStageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] stage_Prefabs;
    [SerializeField] private GameObject stage_Field;
    public bool stage_Clear = false;
    private Queue<GameObject> stages = new Queue<GameObject>();
    private GameObject _stages;

    private void Start()
    {
        Stage_Start();
    }

    private void Stage_Start()
    {
        _stages = Instantiate(stage_Prefabs[0], stage_Field.transform);
        
    }
    
    private void Delet_Stage()
    {
        if (stage_Clear)
        {
            stage_Clear = false;
            Debug.Log("다음 스테이지로");
            Destroy(_stages);
        }
    }
}
