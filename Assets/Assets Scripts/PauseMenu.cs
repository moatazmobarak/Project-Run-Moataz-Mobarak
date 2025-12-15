using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public GameObject pauseMenuUI;
    public Slider volumeSlider;

    private bool isPaused = false;

    void Awake()
{
    if (instance == null)
        instance = this;
    else
        Destroy(gameObject);
}

    void Start()
    {
        pauseMenuUI.SetActive(false);
        AudioListener.volume = volumeSlider.value;
    }

void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.isGameOver)
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }
}


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    public void ForceClose()
{
    pauseMenuUI.SetActive(false);
    isPaused = false;
}


    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
