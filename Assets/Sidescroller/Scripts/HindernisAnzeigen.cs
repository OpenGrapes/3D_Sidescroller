using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HindernisAnzeigen : MonoBehaviour
{
    //Feld für die Zeit
    public int zeitZaehler = 2;
    void Update()
    {
        //gibt es einen Rest?
        if ((int)Time.time % zeitZaehler != 0)
        {
            //dann zeigen wir das Objekt an
            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().enabled = true;
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}