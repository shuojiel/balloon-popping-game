using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 2.0f;        // 障碍物移动速度
    private bool movingRight = true;      // 当前移动方向
    private float leftBoundary = -8.89f;  // 左边界
    private float rightBoundary = 8.89f;  // 右边界

    void Update()
    {
        // 左右来回移动
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x > rightBoundary)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x < leftBoundary)
                movingRight = true;
        }
    }

    // 检测子弹碰撞
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // 销毁子弹
        }
    }
}
