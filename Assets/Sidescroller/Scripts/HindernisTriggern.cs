using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HindernisTriggern : MonoBehaviour
{
    // Öffentliches Feld für das andere Objekt, das das Skript hat
    public GameObject anderesObjekt = null; // Das Zielobjekt, dessen Skript aktiviert/deaktiviert werden soll

    // Das Skript, das umgeschaltet werden soll
    public MonoBehaviour zielSkript;

    // Event bei Eintritt in den Triggerbereich
    void OnTriggerEnter(Collider other)
    {
        // Überprüfen, ob das andere Objekt zugewiesen wurde
        if (anderesObjekt != null && zielSkript != null)
        {
            // Umschalten des spezifischen Skripts
            zielSkript.enabled = !zielSkript.enabled;  // Toggle the script
            Debug.Log("Skript auf " + anderesObjekt.name + " wurde " + (zielSkript.enabled ? "aktiviert" : "deaktiviert") + ".");
        }
    }
}
