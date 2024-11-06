using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float moveSpeed = 2.0f;               // �ƶ��ٶȣ�������Inspector������
    public float maxSizeMultiplier = 2.0f;       // �������Ŵ�ı���
    public float growthRate = 0.1f;              // ����Ŵ���ٶ�
    public AudioClip explosionSound;             // ��ը��Ч
    private Vector3 originalScale;               // ��ʼ��С
    private bool movingRight = true;             // ���������ƶ�����
    private float leftBoundary = -8.89f;         // ��߽�
    private float rightBoundary = 8.89f;         // �ұ߽�

    void Start()
    {
        originalScale = transform.localScale;    // ��¼����ĳ�ʼ��С
    }

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

        // ��ʱ������
        transform.localScale += Vector3.one * growthRate * Time.deltaTime;

        // ����Ƿ�ﵽ����С����ը����������
        if (transform.localScale.x >= originalScale.x * maxSizeMultiplier)
        {
            Explode();
        }
    }

    // ����ը
    public void Explode()
    {
        // ���ű�ը��Ч
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position); // ���̲�����Ч
        }

        // ���������������
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Explode();          // ���ű�ը��Ч����������
            Destroy(other.gameObject);  // �����ӵ�
        }
    }
}
