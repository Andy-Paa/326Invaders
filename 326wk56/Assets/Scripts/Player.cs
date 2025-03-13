using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shottingOffset;
    public Animator animator; // 添加Animator引用
    public AudioSource audioSource; // 添加AudioSource引用
    public AudioClip shootClip; // 添加射击声音片段
    public AudioClip collisionClip; // 添加碰撞声音片段

    private float shotCooldown = 0.33f; // 每秒三发
    private float lastShotTime;
    private float moveSpeed = 5f; // 移动速度
    private bool isDead = false; // 玩家是否死亡的标志

    // Update is called once per frame
    void Update()
    {
        if (isDead) return; // 如果玩家死亡，则不执行以下逻辑

        // 射击逻辑
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShotTime + shotCooldown)
        {
            lastShotTime = Time.time;
            GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");
            audioSource.PlayOneShot(shootClip); // 播放射击声音
            Destroy(shot, 4f);

            animator.SetTrigger("Shoot"); // 触发射击动画
        }

        // 移动逻辑
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(move, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, -5f, 5f); // 限制玩家在 x 轴的范围
        transform.position = newPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            Debug.Log("F!");
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(collisionClip); // 播放碰撞声音
            animator.SetTrigger("die"); // 触发爆炸动画
            isDead = true; // 设置玩家死亡标志
            StartCoroutine(HandlePlayerDeath());
        }
    }

    private IEnumerator HandlePlayerDeath()
    {
        yield return new WaitForSeconds(2f); // 等待2秒
        SceneManager.LoadScene("cre"); // 跳转到名为"cre"的场景
    }
}
