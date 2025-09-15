using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MauerBauen : MonoBehaviour
{
    public Transform wuerfelPrefab; // Der Würfel, der als Baustein verwendet wird
    public int hoehe = 5;           // Höhe der Mauer
    public int breite = 10;         // Breite der Mauer
    public float abstand = 1.1f;    // Abstand zwischen den Würfeln

    void Start()
    {
        // Die Größe des Meshes des aktuellen Objekts beschaffen
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("Es wird ein Objekt mit Mesh benötigt");
            return;
        }

        // Überprüfen, ob ein Würfel übergeben wurde
        if (wuerfelPrefab == null)
        {
            Debug.LogError("Es muss ein WürfelPrefab übergeben werden");
            return;
        }

        // Das Mesh und die Skalierung des Objekts beschaffen
        Mesh mesh = meshFilter.mesh;
        Vector3 groesse = mesh.bounds.size;
        Vector3 skalierung = transform.localScale;

        // Die Grenzen für die Mauer ermitteln
        float startX = transform.position.x - (groesse.x * skalierung.x) / 2;
        float startY = transform.position.y;

        // Die Mauer erstellen
        for (int y = 0; y < hoehe; y++) // Höhe
        {
            for (int x = 0; x < breite; x++) // Breite
            {
                // Position für den aktuellen Würfel berechnen
                Vector3 position = new Vector3(
                    startX + x * abstand,
                    startY + y * abstand,
                    transform.position.z
                );

                // Würfel an der berechneten Position instanziieren
                Instantiate(wuerfelPrefab, position, wuerfelPrefab.rotation);
            }
        }
    }
}