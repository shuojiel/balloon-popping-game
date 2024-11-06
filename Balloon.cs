using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float moveSpeed = 2.0f;               // 移动速度，可以在Inspector中设置
    public float maxSizeMultiplier = 2.0f;       // 气球最大放大的倍数
    public float growthRate = 0.1f;              // 气球放大的速度
    public AudioClip explosionSound;             // 爆炸音效
    private Vector3 originalScale;               // 初始大小
    private bool movingRight = true;             // 控制左右移动方向
    private float leftBoundary = -8.89f;         // 左边界
    private float rightBoundary = 8.89f;         // 右边界

    void Start()
    {
        originalScale = transform.localScale;    // 记录气球的初始大小
    }

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

        // 随时间增大
        transform.localScale += Vector3.one * growthRate * Time.deltaTime;

        // 检查是否达到最大大小，爆炸并销毁气球
        if (transform.localScale.x >= originalScale.x * maxSizeMultiplier)
        {
            Explode();
        }
    }

    // 气球爆炸
    public void Explode()
    {
        // 播放爆炸音效
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position); // 立刻播放音效
        }

        // 立刻销毁气球对象
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Explode();          // 播放爆炸音效并销毁气球
            Destroy(other.gameObject);  // 销毁子弹
        }
    }
}
