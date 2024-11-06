using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;    // 气球的预制件
    public float spawnInterval = 2.0f;  // 生成气球的时间间隔
    private float leftBoundary = -8.89f; // 左边界
    private float rightBoundary = 8.89f; // 右边界
    private float topPosition = 3.5f;   // 再次降低的 Y 位置，确保气球不会超出地图边界
    private int maxBalloons = 3;        // 地图上允许的最大气球数量

    void Start()
    {
        // 开始循环生成气球
        InvokeRepeating("SpawnBalloon", 0, spawnInterval);
    }

    void SpawnBalloon()
    {
        // 检查当前气球数量是否达到最大值
        if (GameObject.FindGameObjectsWithTag("Balloon").Length >= maxBalloons)
        {
            return; // 已达最大数量，停止生成
        }

        // 随机生成 X 坐标
        float randomX = Random.Range(leftBoundary, rightBoundary);
        Vector3 spawnPosition = new Vector3(randomX, topPosition, 0);

        // 在随机位置生成气球
        GameObject balloon = Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
        balloon.tag = "Balloon"; // 确保气球对象带有 "Balloon" 标签
    }
}
