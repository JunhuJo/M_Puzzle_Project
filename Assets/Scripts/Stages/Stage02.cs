using UnityEngine;
using UnityEngine.UI;

public class Stage02 : MonoBehaviour
{
    [SerializeField] private PlayManager playManager;

    [Header("Stage02")]
    [SerializeField] private GameObject stage02;
    [SerializeField] private GameObject stage03_Field;
    [SerializeField] private GameObject map;
    [SerializeField] private Button down_Btn;
    private int stage02_count = 0;
    private Vector3 area = new Vector3(0, -278, 0);

    private void Start()
    {
        //스테이지 2
        down_Btn.onClick.AddListener(Move_map);
    }

    #region 2 Stage
    public void Move_map()
    {
        map.transform.Translate(Vector2.down * 20);
        stage02_count++;

        if (stage02_count == 62)
        {
            stage02.gameObject.SetActive(false);
            stage03_Field.gameObject.SetActive(true);
            playManager.Stages[2].SetActive(true);
        }
    }
    #endregion
}
