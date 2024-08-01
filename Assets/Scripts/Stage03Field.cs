using UnityEngine;

public class Stage03Field : MonoBehaviour
{
    [SerializeField] private GameObject down_Enemy;
    private float speed = 0.05f;


    private void Update()
    {
        Enemy_Move();
    }

    private void Enemy_Move()
    {
        down_Enemy.transform.Translate(Vector3.down * speed);
        if (down_Enemy.transform.position.y <=0 )
        {
            down_Enemy.transform.Translate(Vector3.zero);
        }
    }
}
