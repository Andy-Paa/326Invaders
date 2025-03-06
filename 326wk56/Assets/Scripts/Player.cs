using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shottingOffset;
    public Animator animator; // 添加Animator引用

    private float shotCooldown = 0.33f; // 每秒三发
    private float lastShotTime;
    private float moveSpeed = 5f; // 移动速度

    // Update is called once per frame
    void Update()
    {
        // 射击逻辑
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShotTime + shotCooldown)
        {
            lastShotTime = Time.time;
            GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");
            Destroy(shot, 4f);

            animator.SetTrigger("Shoot"); // 触发射击动画
        }

        // 移动逻辑
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(move, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, -3f, 3f); // 限制玩家在 x 轴的范围
        transform.position = newPosition;
    }
}
