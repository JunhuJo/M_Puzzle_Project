using UnityEngine;
using UnityEngine.UI;

public class Stage03 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button left;
    [SerializeField] private Button right;

    private void OnEnable()
    {
        left.gameObject.SetActive(true);
        right.gameObject.SetActive(true);

        left.onClick.AddListener(Left);
        right.onClick.AddListener(Right);
    }

    public void Left()
    {
        player.transform.Translate(Vector3.left * 0.2f);
    }

    public void Right()
    {
        player.transform.Translate(Vector3.right * 0.2f);
    }
}
