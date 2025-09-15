using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelMenuScript : MonoBehaviour
{
    public GameObject levelMenu;
    public TextMeshProUGUI pauseResumeText;
    float oldTimeScale = 1f;
    private bool isPaused = false;

    void Start()
    {
        ResetMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (levelMenu.activeSelf)
            {
                ResetMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }

    private void ShowMenu()
    {
        levelMenu.SetActive(true);
        // Wenn das Menü geöffnet wird, zeigen wir immer "Pause"
        pauseResumeText.text = "Pause";
        // isPaused bleibt unverändert, da das Öffnen des Menüs nichts mit dem Pause-Zustand zu tun hat
    }

    public void TogglePause()
    {
        if (!isPaused)
        {
            // Pause aktivieren
            oldTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            pauseResumeText.text = "Fortsetzen";
            isPaused = true;
        }
        else
        {
            // Spiel fortsetzen
            levelMenu.SetActive(false);
            Time.timeScale = oldTimeScale;
            pauseResumeText.text = "Pause";
            isPaused = false;
        }
    }

    private void ResetMenu()
    {
        levelMenu.SetActive(false);
        Time.timeScale = oldTimeScale;
        isPaused = false;
        pauseResumeText.text = "Pause";
    }

    public void StartMenu()
    {
        ResetMenu();
        SceneManager.LoadScene("StartMenü");
    }

    public void ButtonExitGeklickt()
    {
        Application.Quit();
        Debug.Log("Spiel beendet");
    }

    public void RestartLevel()
    {
        ResetMenu();
        SpielAnzeigeScript.sceneReset = true;
    }
}