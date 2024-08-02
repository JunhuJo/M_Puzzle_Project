using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KGSpwner : MonoBehaviour
{
    [SerializeField] private GameObject[] kg_Prefab;
    [SerializeField] private Transform kg_Pos;
    //[SerializeField] private bool set_KG = false;

    private void Start()
    {
        Set_KG();
    }
    //private void Update()
    //{
    //    Set_KG();
    //}

    private void Set_KG()
    {
       
            for (int i = 0; i < kg_Prefab.Length; i++)
            {
                GameObject kg = Instantiate(kg_Prefab[i], kg_Pos.transform);
            }
            
      
    }
}
