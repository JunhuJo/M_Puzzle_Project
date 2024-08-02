using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage04 : MonoBehaviour
{
    [SerializeField] private Button left;
    [SerializeField] private Button right;

    [SerializeField] private GameObject left_Bar;
    private bool On_left_Bar = false;

    [SerializeField] private GameObject right_Bar;
    private bool On_right_Bar = false;
    float t = 0;
    float rotationSpeed = 10.0f;

    private void Start()
    {
        left.onClick.AddListener(On_Click_Left_Bar);
        right.onClick.AddListener(On_Click_Right_Bar);
    }

    private void Update()
    {
        Move_Bar();
    }

    public void On_Click_Left_Bar()
    {
        On_left_Bar = true;
    }

    public void On_Click_Right_Bar()
    {
        On_right_Bar = true;
    }

    private void Move_Bar()
    {
        if (On_left_Bar)
        {
            StartCoroutine(RotateBar(left_Bar.transform));
            On_left_Bar = false;
        }

        if (On_right_Bar)
        {
            StartCoroutine(RotateBar(right_Bar.transform));
            On_right_Bar = false;
        }
    }

    private IEnumerator RotateBar(Transform barTransform)
    {
        Quaternion startRotation = barTransform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, 35);
        if(On_left_Bar)
        {
            targetRotation = Quaternion.Euler(0, 0, -35);
        }


        // 위쪽으로 회전
        while (t < 1.0f)
        {
            t += Time.deltaTime * rotationSpeed;
            barTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        //yield return new WaitForSeconds(0.1f);

        // 초기 상태로 회전 초기화
        t = 0;

        // 원래 자리로 돌아가기
        while (t < 1.0f)
        {
            t += Time.deltaTime * rotationSpeed;
            barTransform.rotation = Quaternion.Slerp(targetRotation, startRotation, t);
            yield return null;
        }

        // 정확히 초기 상태로 맞추기
        barTransform.rotation = startRotation;
    }
}
