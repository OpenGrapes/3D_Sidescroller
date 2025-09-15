using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Menu : MonoBehaviour
{
    //für die Anzeige der Credits
    bool showCredits = false;
    float creditsXPos;
    void Start()
    {
    }

    public void ButtonLevel1Geklickt()
    {
        SceneManager.LoadScene("Level1");
        SpielAnzeigeScript.sceneReset = true;
    }
    public void ButtonLevel2Geklickt()
    {
        SceneManager.LoadScene("Level2");
        SpielAnzeigeScript.sceneReset = true;
    }
    public void ButtonScoreBoardClicked()
    {
        GameOverPunkte.punkteGlobal = 0; // Reset der Punkte für das Scoreboard
        SceneManager.LoadScene("ScoreBoard");
    }
    public void ButtonExitGeklickt()
    {
        Application.Quit();
        Debug.Log("Spiel beendet");
    }
}