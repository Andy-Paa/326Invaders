using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyRoot : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 direction = Vector3.right;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // 碰到边界反转方向并下降
        if (transform.position.x > 2 || transform.position.x < -2)
        {
            direction = -direction;
            transform.position += Vector3.down * 0.5f; // 敌人向下移动
        }
    }
}
