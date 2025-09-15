using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadThisScene : MonoBehaviour
{
    public delegate void TriggerAktion(); // Delegat für die Trigger-Aktion
    public static event TriggerAktion OnTrigger; // Event für den Trigger

    void OnTriggerEnter() // Trigger wird ausgelöst
    {
        OnTrigger?.Invoke(); // Event auslösen, wenn es Abonnenten gibt
        
        // Hole den Namen der aktuellen Szene und lade diese neu
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}