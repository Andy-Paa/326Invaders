using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;

    public int scoreValue = 3; // 该敌人提供的分数

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // 确保是子弹命中
        {
            Debug.Log("Ouch!");

            Destroy(collision.gameObject); // 销毁子弹
            OnEnemyDied?.Invoke(scoreValue); // 触发事件并传递得分
            Destroy(gameObject); // 销毁敌人
        }
    }
}
