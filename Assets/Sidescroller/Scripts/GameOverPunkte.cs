using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPunkte : MonoBehaviour
{
    // Öffentliche Felder für die Anzeige und den Button
    public static int punkteGlobal;
    public TextMeshProUGUI punkteAnzeige;
    public Button scoreButton;
    public TextMeshProUGUI infoText;

    void Start()
    {
        // Punktzahl anzeigen
        punkteAnzeige.text = "Gesammelte Punkte: " + punkteGlobal.ToString();

        // Button nur zeigen, wenn Punktzahl hoch genug ist
        if (punkteGlobal >= 100)
        {
            scoreButton.gameObject.SetActive(true);
            if (infoText != null)
                infoText.text = "Du kannst deinen Score eintragen.";
        }
        else
        {
            scoreButton.gameObject.SetActive(false);
            if (infoText != null)
                infoText.text = "Nicht genug Punkte für die Highscore-Liste.";
        }
    }

    // Wird über Button aufgerufen
    public void WechsleZuScoreboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }
}
