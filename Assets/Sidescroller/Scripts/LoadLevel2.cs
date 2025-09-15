using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel2 : MonoBehaviour
{
    public GameObject TimeBoost; // Referenz auf das Prefab für den Zeitboost

    void OnTriggerEnter()
    {
        UnityEngine.SceneManagement.
        SceneManager.LoadScene("Level2");
        TimeBoost.SetActive(true); // Aktivieren des Zeitboosts
    }
}