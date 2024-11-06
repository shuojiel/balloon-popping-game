using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon"))
        {
            // �ҵ� BalloonCounter �����»��Ƽ���
            BalloonCounter counter = FindObjectOfType<BalloonCounter>();
            if (counter != null)
            {
                counter.BalloonDestroyed();
            }

            // �����ӵ�������
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
