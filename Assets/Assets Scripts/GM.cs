using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    private float survivalTime = 0f;

    public GameObject gameOverUI;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI timeSurvivedText;

    void Start()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (!isGameOver)
        {
            survivalTime += Time.deltaTime;
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;
        PauseMenu.instance?.ForceClose();
        gameOverUI.SetActive(true);

        finalScoreText.text = "Score: " + ScoreManager.instance.score;
        timeSurvivedText.text = "Time: " + survivalTime.ToString("F1") + "s";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    
}
