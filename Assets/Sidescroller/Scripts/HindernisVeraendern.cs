using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HindernisVeraendern : MonoBehaviour
{
    // Öffentliche Felder für die Geschwindigkeit, die Aktion, die Richtung und die Schritte
    public int geschwindigkeit = 100;
    public int aktion = 1;
    public bool bewegenX = false;
    public bool bewegenY = false;
    public bool bewegenZ = false;
    public int schritte = 0;

    // Private Felder für die Steuerung
    float sekunden = 0;
    bool nochEinmal = true;

    void Start()
    {
    }

    void Update()
    {
        // Soll noch eine Veränderung durchgeführt werden?
        // Wenn nein, Funktion verlassen
        if (nochEinmal == false)
            return;

        // Soll mitgezählt werden?
        if (schritte != 0)
        {
            // Mitzählen, wie viele Sekunden vergangen sind
            sekunden = sekunden + Time.deltaTime;
        }

        // Die Nachkommastellen abschneiden
        // Haben wir die vorgegebene Anzahl erreicht?
        if ((int)sekunden == schritte)
        {
            // Dann aufhören
            nochEinmal = false;
        }

        // Bewegungswerte initialisieren
        float veraendernX = 0;
        float veraendernY = 0;
        float veraendernZ = 0;
        float veraenderung = geschwindigkeit * Time.deltaTime;

        // In welche Richtung wird verändert?
        if (bewegenX == true)
            veraendernX = veraenderung;
        if (bewegenY == true)
            veraendernY = veraenderung;
        if (bewegenZ == true)
            veraendernZ = veraenderung;

        // Was soll gemacht werden?
        switch (aktion)
        {
            case 1: // Bei 1 drehen wir das Objekt
                transform.Rotate(veraendernX, veraendernY, veraendernZ);
                break;

            case 2: // Bei 2 verschieben wir das Objekt
                transform.Translate(veraendernX, veraendernY, veraendernZ);
                break;

            case 3: // Bei 3 skalieren wir das Objekt
                // Das geht nur über Veränderung von localScale
                transform.localScale = transform.localScale + new Vector3(veraendernX, veraendernY, veraendernZ);
                break;

            // Sonst geben wir eine Meldung aus
            default:
                Debug.Log("Es wurde keine gültige Aktion gewählt.");
                break;
        }
    }
}
