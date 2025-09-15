using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverGrund : MonoBehaviour
{
    // Öffentliche Felder für die beiden Steuerelemente zur Ausgabe
    public TextMeshProUGUI gameOverGrundAnzeige;

    void Start()
    {
        if ( SpielAnzeigeScript.lebenGlobal <= 0)
        {
            gameOverGrundAnzeige.text = "Keine Leben Mehr!"; // Beispieltext für den GameOver-Grund
        }
        else
        {
            gameOverGrundAnzeige.text = "Die Zeit ist abgelaufen!"; // Beispieltext für den GameOver-Grund
        }
    }
}