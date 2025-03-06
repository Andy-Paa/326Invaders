using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;

    public int scoreValue = 3; // 该敌人提供的分数
    public GameObject bulletPrefab; // 敌人的子弹预制件
    public Transform shootingOffset; // 射击位置
    public float minShootInterval = 1f; // 最小射击间隔
    public float maxShootInterval = 3f; // 最大射击间隔

    private float nextShootTime;

    void Start()
    {
        ScheduleNextShoot();
    }

    void Update()
    {
        if (Time.time >= nextShootTime)
        {
            Shoot();
            ScheduleNextShoot();
        }
    }

    void ScheduleNextShoot()
    {
        nextShootTime = Time.time + Random.Range(minShootInterval, maxShootInterval);
    }

    void Shoot()
    {
        GameObject shot = Instantiate(bulletPrefab, shootingOffset.position, Quaternion.identity);
        Destroy(shot, 4f); // 4秒后销毁子弹
    }

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
