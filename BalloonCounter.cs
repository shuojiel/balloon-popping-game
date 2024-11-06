    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement; // 导入场景管理

    public class BalloonCounter : MonoBehaviour
    {
        public static BalloonCounter Instance;

        public TextMeshProUGUI balloonCounterText;
        public int targetBalloons = 10;  // 可以在 Inspector 中调整所需击破的气球数
        private int balloonsDestroyed = 0;

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            UpdateBalloonCounterUI();
        }

        public void BalloonDestroyed()
        {
            balloonsDestroyed++;
            UpdateBalloonCounterUI();

            if (balloonsDestroyed >= targetBalloons)
            {
                LoadNextScene(); // 达到目标，加载下一个场景
            }
        }

        void UpdateBalloonCounterUI()
        {
            if (balloonCounterText != null)
            {
                balloonCounterText.text = $"Balloons: {balloonsDestroyed}/{targetBalloons}";
            }
        }

        void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            // 检查是否有下一个场景
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("已到达最后一个场景");
            }
        }
    }
