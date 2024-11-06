using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;    // �����Ԥ�Ƽ�
    public float spawnInterval = 2.0f;  // ���������ʱ����
    private float leftBoundary = -8.89f; // ��߽�
    private float rightBoundary = 8.89f; // �ұ߽�
    private float topPosition = 3.5f;   // �ٴν��͵� Y λ�ã�ȷ�����򲻻ᳬ����ͼ�߽�
    private int maxBalloons = 3;        // ��ͼ������������������

    void Start()
    {
        // ��ʼѭ����������
        InvokeRepeating("SpawnBalloon", 0, spawnInterval);
    }

    void SpawnBalloon()
    {
        // ��鵱ǰ���������Ƿ�ﵽ���ֵ
        if (GameObject.FindGameObjectsWithTag("Balloon").Length >= maxBalloons)
        {
            return; // �Ѵ����������ֹͣ����
        }

        // ������� X ����
        float randomX = Random.Range(leftBoundary, rightBoundary);
        Vector3 spawnPosition = new Vector3(randomX, topPosition, 0);

        // �����λ����������
        GameObject balloon = Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
        balloon.tag = "Balloon"; // ȷ������������ "Balloon" ��ǩ
    }
}
