    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement; // ���볡������

    public class BalloonCounter : MonoBehaviour
    {
        public static BalloonCounter Instance;

        public TextMeshProUGUI balloonCounterText;
        public int targetBalloons = 10;  // ������ Inspector �е���������Ƶ�������
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
                LoadNextScene(); // �ﵽĿ�꣬������һ������
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

            // ����Ƿ�����һ������
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("�ѵ������һ������");
            }
        }
    }
