using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;            // 玩家移动速度
    public GameObject bulletPrefab;           // 子弹的预制件
    public Transform bulletSpawnPoint;        // 子弹发射位置
    public float bulletSpeed = 10.0f;         // 子弹速度
    public AudioClip shootSound;              // 发射子弹的音效
    private AudioSource audioSource;          // 音频源组件

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // 获取 AudioSource 组件
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // 如果没有，自动添加
        }
    }

    void Update()
    {
        // 玩家左右移动
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.position += movement;

        // 发射子弹
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.up * bulletSpeed;  // 子弹向上移动
        }

        // 播放发射音效
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound); // 使用 PlayOneShot 播放音效
        }
    }
}
