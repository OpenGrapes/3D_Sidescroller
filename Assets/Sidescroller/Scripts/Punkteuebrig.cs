using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punkteuebrig : MonoBehaviour
{
    public Image muenzBild;

    private string muenzBildTag = "CoinBild"; 
    private string muenzTag = "Coin";
    private int letzteAnzahlCoins = -1;

    void Update()
    {
        int aktuelleAnzahl = GameObject.FindGameObjectsWithTag(muenzTag).Length;
        if (aktuelleAnzahl != letzteAnzahlCoins)
        {
            letzteAnzahlCoins = aktuelleAnzahl;
            AktualisiereAnzeige();
        }
    }

    void AktualisiereAnzeige()
    {
        foreach (GameObject muenzBildObj in GameObject.FindGameObjectsWithTag(muenzBildTag))
        {
            Destroy(muenzBildObj);
        }

        for (int i = 0; i < letzteAnzahlCoins; i++)
        {
            Image anzeigeBild = Instantiate(muenzBild, transform);
            anzeigeBild.tag = muenzBildTag;
        
            // Position relativ zum Prefab-Bild setzen
            RectTransform rt = anzeigeBild.GetComponent<RectTransform>();
            Vector2 startPos = muenzBild.rectTransform.anchoredPosition;
            rt.anchoredPosition = new Vector2(startPos.x + i * 71, startPos.y);
        }
    }
}