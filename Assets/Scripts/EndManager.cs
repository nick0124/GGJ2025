using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject pausePopup; // Ссылка на попап меню

    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1; // Обновляем таймскейл, чтобы игра начиналась с нормальной скоростью
        pausePopup.SetActive(false); // Скрываем попап при старте игры
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Останавливаем время
        pausePopup.SetActive(true); // Показываем попап
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Возобновляем время
        pausePopup.SetActive(false); // Скрываем попап
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Убеждаемся, что время запущено перед перезапуском
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезагружаем текущую сцену
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1; // Убеждаемся, что время запущено перед выходом в главное меню
        SceneManager.LoadScene("MainMenu"); // Замените "MainMenu" на имя вашей сцены с главным меню
    }
}
