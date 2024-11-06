using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            // 找到 BalloonCounter 并更新击破计数
            BalloonCounter counter = FindObjectOfType<BalloonCounter>();
            if (counter != null)
            {
                counter.BalloonDestroyed();
            }

            // 销毁子弹和气球
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }
    }
}
