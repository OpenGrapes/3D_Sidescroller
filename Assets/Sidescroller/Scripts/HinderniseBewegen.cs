using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HinderniseBewegen : MonoBehaviour
{
    // Öffentliche Felder für die Einstellungen
    public float geschwindigkeit = 2f;   // Geschwindigkeit der Bewegung
    public float distanz = 5f;           // Maximale Distanz, die das Objekt sich hin und her bewegt
    public bool bewegenX = true;         // Aktiviert die Bewegung in der X-Achse
    public bool bewegenY = false;        // Aktiviert die Bewegung in der Y-Achse
    public bool bewegenZ = false;        // Aktiviert die Bewegung in der Z-Achse

    // Private Felder für die Bewegung
    private Vector3 startPosition;       // Die Startposition des Objekts
    private Vector3 zielPosition;        // Die Zielposition des Objekts
    private bool bewegtRichtung = true;  // Flag, ob die Bewegung vorwärts oder rückwärts geht

    void Start()
    {
        // Die Startposition des Objekts festlegen
        startPosition = transform.position;
        // Die Zielposition basierend auf der Distanz berechnen
        zielPosition = startPosition + new Vector3(bewegenX ? distanz : 0, bewegenY ? distanz : 0, bewegenZ ? distanz : 0);
    }

    void Update()
    {
        // Berechne die Geschwindigkeit
        float step = geschwindigkeit * Time.deltaTime;

        // Objekt hin und her bewegen
        if (bewegtRichtung)
        {
            transform.position = Vector3.MoveTowards(transform.position, zielPosition, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
        }

        // Wenn das Objekt die Zielposition erreicht hat, Richtungswechsel
        if (transform.position == zielPosition || transform.position == startPosition)
        {
            bewegtRichtung = !bewegtRichtung; // Richtung umkehren
        }
    }
}
