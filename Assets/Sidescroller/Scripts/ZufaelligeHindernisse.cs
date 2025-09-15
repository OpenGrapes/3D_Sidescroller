using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZufaelligeHindernisse : MonoBehaviour
{
    //für das Hindernis
    public Transform hindernis;
    public int zaehler;
    void Start()
    {
        //die Größe beschaffen über den MeshFilter
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        //hat das Objekt einen MeshFilter
        if (meshFilter == null)
        {
            Debug.Log("Es wird ein Objekt mit Mesh benötigt");
            return;
        }
        //ist ein Hindernis übergeben worden
        if (hindernis == null)
        {
            Debug.Log("Es muss ein Hindernis übergeben werden");
            return;
        }
        //das Mesh über den MeshFilter beschaffen
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3 groesse = mesh.bounds.size;
        Vector3 skalierung = transform.localScale;
        //die Grenzen für das Mesh ermitteln
        int maxX = (int)(groesse.x * skalierung.x) / 2;
        int maxZ = (int)(groesse.z * skalierung.z) / 2;
        //die Instanzen erzeugen
        for (int i = 0; i < zaehler; i++)
        {
            //eine zufällige Position ermitteln
            Vector3 position = new
            Vector3(Random.Range(transform.position.x - maxX,
            transform.position.x + maxX), hindernis.position.y,
            Random.Range(transform.position.z - maxZ,
            transform.position.z + maxZ));
            //die Instanz des Hindernisses erzeugen
            Instantiate(hindernis, position, hindernis.rotation);
        }
    }
}