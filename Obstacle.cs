using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 2.0f;        // �ϰ����ƶ��ٶ�
    private bool movingRight = true;      // ��ǰ�ƶ�����
    private float leftBoundary = -8.89f;  // ��߽�
    private float rightBoundary = 8.89f;  // �ұ߽�

    void Update()
    {
        // ���������ƶ�
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

    // ����ӵ���ײ
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // �����ӵ�
        }
    }
}
