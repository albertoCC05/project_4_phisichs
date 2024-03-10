
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class UImanager : MonoBehaviour
{

    // variables
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioSource cameraAudiosource;
    [SerializeField] private TMP_Dropdown languageDropdown;

    [SerializeField] private TextMeshProUGUI playButtonText;
    [SerializeField] private TextMeshProUGUI otionsButtonText;
    [SerializeField] private TextMeshProUGUI exitButtonText;
    [SerializeField] private TextMeshProUGUI backButtonText;
    [SerializeField] private TextMeshProUGUI languageNearDropdownText;
    [SerializeField] private TextMeshProUGUI musicSliderText;
    [SerializeField] private TextMeshProUGUI optionsTitleText;

    [SerializeField] private TextMeshProUGUI enemiesLefttext;

    // functions
    public void UpdateEnemiesText(int enemiesInScene, int enemiesPerWave)
    {
        enemiesLefttext.text = $"enemies: {enemiesInScene} / {enemiesPerWave}";
    }
    public void PauseGame()
    {
        ShowPausePanel();
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        HidePausePanel();
        Time.timeScale = 1;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }
    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
    }
    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }
    public void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangeVolume()
    {
        cameraAudiosource.volume = musicSlider.value;
    }
    public void CloseGame()
    {
        Application.Quit();

    }
    private void ChangeToSpanish()
    {
        playButtonText.text = "Jugar";
        otionsButtonText.text = "Opciones";
        optionsTitleText.text = "Opciones";
        exitButtonText.text = "Salir";
        backButtonText.text = "volver";
        musicSliderText.text = "Volumen";
        languageNearDropdownText.text = "Idioma";

    }
    private void ChangeToEnglish()
    {
        playButtonText.text = "Play";
        otionsButtonText.text = "Options";
        optionsTitleText.text = "Options";
        exitButtonText.text = "Exit";
        backButtonText.text = "Back";
        musicSliderText.text = "Volume";
        languageNearDropdownText.text = "Language";
    }
    public void ChangeLanguage()
    {
        if (languageDropdown.value == 0)
        {
            ChangeToEnglish();
        }
        if (languageDropdown.value == 1)
        {
            ChangeToSpanish();
        }

    }
    // events

    private void Start()
    {
        Time.timeScale = 1;
        HideGameOverPanel();
        HidePausePanel();
        HideOptionsPanel();
        Screen.SetResolution( 1920,  1080 , false);
    }

}
