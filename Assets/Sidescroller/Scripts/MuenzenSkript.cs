using UnityEngine;

public class MuenzenSkript : MonoBehaviour
{
    // geschwindigkeit der Münzdrehung
    public int drehgeschwindigkeit = 2;
    void Update()
    {
        // Die Münze soll rotieren
        transform.Rotate(0, drehgeschwindigkeit, 0, Space.World);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameOverPunkte.punkteGlobal += 100;
            Destroy(gameObject);
        }
    }
}