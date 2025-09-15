using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreboardUI : MonoBehaviour
{
    public TMP_Text namensListeText;
    public TMP_InputField nameEingabeFeld;
    public Button speichernButton;
    public TMP_Text nameHinweisText;
    public HighscoreManager highscoreManager;

    private int punkte;

    void Start()
    {
        punkte = GameOverPunkte.punkteGlobal;
        ZeigeHighscores();

        // Prüfen ob mindestens 100 Punkte erreicht wurden
        bool darfEintragen = punkte >= 100;

        // Nur Eingabefelder anzeigen, wenn genug Punkte da sind
        nameEingabeFeld.gameObject.SetActive(darfEintragen);
        speichernButton.gameObject.SetActive(darfEintragen);
        nameHinweisText.gameObject.SetActive(darfEintragen);
    }

    public void Speichern()
    {
        string name = nameEingabeFeld.text.Trim();

        var existierend = highscoreManager.highscoreListe.Find(e => e.name == name);

        if (punkte >= 100 || (existierend != null && punkte > existierend.punkte))
        {
            PlayerPrefs.SetString("Spielername", name);
            PlayerPrefs.Save();

            highscoreManager.VersucheHighscoreEintrag(punkte);
            speichernButton.interactable = false;
            ZeigeHighscores();
        }
    }

    void ZeigeHighscores()
    {
        namensListeText.text = "Platz\t\tName\tPunkte\n";

        List<ScoreEintrag> liste = highscoreManager.highscoreListe;
        for (int i = 0; i < liste.Count; i++)
        {
            var eintrag = liste[i];
            string platz = (i + 1).ToString().PadLeft(2, '0');
            string name = eintrag.name.PadRight(10);
            string punkte = eintrag.punkte.ToString();
            namensListeText.text += $"{platz}.\t\t{name}\t{punkte}\n";
        }
    }
}