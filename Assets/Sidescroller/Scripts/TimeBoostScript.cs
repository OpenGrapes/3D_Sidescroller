using UnityEngine;

public class TimeBoostScript : MonoBehaviour
{
// geschwindigkeit der Münzdrehung
    public int drehgeschwindigkeit = 2;
    public GameObject TimeBoost; // Referenz auf das Prefab für den Zeitboost

    void Update()
    {
        // Die Uhr soll rotieren
        transform.Rotate(0, drehgeschwindigkeit, 0, Space.World);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpielAnzeigeScript.zeitGlobal += 120f; // Zeit hinzufügen
            Destroy(gameObject);
            TimeBoost.SetActive(false); // Deaktivieren des Zeitboosts
        }
    }
}
