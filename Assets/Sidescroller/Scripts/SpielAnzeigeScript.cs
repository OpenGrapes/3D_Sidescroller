using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SpielAnzeigeScript : MonoBehaviour
{
    // Static-Werte
    public static SpielAnzeigeScript instance;  // Singleton-Instanz
    public static int lebenGlobal;    // Anzahl an Leben Global
    public static bool sceneReset; // Flag für Szenen-Reset
    public static float zeitGlobal; // Globale Zeit, falls benötigt

    // Varibale
    public float zeitLimit = 120f; // Zeitlimit für das Spiel
    public int aktuelleLeben = 5; // Anzahl an Leben
    public GameObject SpielAnzeige; // Referenz auf das Spielanzeige-Objekt

    // UI
    public Canvas canvas;          // Canvas für die UI
    public Image herzBild;          // Bild für die Lebenanzeige
    public TextMeshProUGUI zeitAnzeige;   // Falls du die Zeit anzeigen willst
    public TextMeshProUGUI punkteAnzeige; // Falls du die Punkte anzeigen willstS

    private string herzBildTag = "Herz";
    private float startZeit;
    private bool gameOverGeladen = false;
    private string gameOverSzene = "GameOver";
    private string startSzene = "StartMenü";
    private string scoreSzene = "ScoreBoard";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Objekt bleibt über Szenen erhalten
            startZeit = Time.time;          // Timer starten
            zeitGlobal = zeitLimit;         // Globale Zeit initialisieren
            lebenGlobal = aktuelleLeben; // Globale Leben initialisieren
            sceneReset = false; // Reset-Flag initialisieren
            SpielAnzeige.SetActive(true); // Aktivieren der Spielanzeige
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Falls es schon existiert, lösche das doppelte Objekt
        }
    }

    void OnEnable()
    {
        LoadThisScene.OnTrigger += LebenAbziehen; // Abonnieren des Events
    }
    void OnDisable()
    {
        LoadThisScene.OnTrigger -= LebenAbziehen; // Abbestellen des Events
    }

    void Update()
    {
        // Zerstöre das Objekt in der GameOver-Szene
        if (SceneManager.GetActiveScene().name == gameOverSzene)
        {
            Destroy(gameObject);
            return;
        }

        // Wenn die Startszene aktiv ist, deaktiviere das Objekt
        if (SceneManager.GetActiveScene().name == startSzene)
        {
            SpielAnzeige.SetActive(false);
            return; // Verhindert weitere Ausführung in der Startszene
        }

        if (SceneManager.GetActiveScene().name == scoreSzene)
        {
            SpielAnzeige.SetActive(false); // Deaktivieren der Spielanzeige in der Score-Szene
            return; // Verhindert weitere Ausführung in der Score-Szene
        }

        if ((SceneManager.GetActiveScene().name != startSzene && !SpielAnzeige.activeSelf) || (SceneManager.GetActiveScene().name != scoreSzene && !SpielAnzeige.activeSelf))
        {
            SpielAnzeige.SetActive(true); // Aktivieren der Spielanzeige, falls sie deaktiviert ist
        }

        // Überprüfen, ob die Zeit abgelaufen ist
        if (!gameOverGeladen && Time.time - startZeit >= zeitGlobal)
        {
            GameOver();
        }

        // Überprüfen, ob Leben aufgebraucht sind
        if (aktuelleLeben <= 0 && !gameOverGeladen)
        {
            GameOver();
        }

        // Zeit und Punkte-Anzeige aktualisieren
        if (zeitAnzeige != null)
        {
            float verbleibendeZeit = Mathf.Max(0, zeitGlobal - (Time.time - startZeit));
            zeitAnzeige.text = ((int)verbleibendeZeit).ToString();

            // Punkte aktualisieren
            punkteAnzeige.text = GameOverPunkte.punkteGlobal.ToString();
        }

        // Leben aktualisieren
        if (lebenGlobal >= 0)
        {
            aktuelleLeben = lebenGlobal;
            AktualisiereHerzAnzeige();
        }

        // Reset der Szene
        if (sceneReset)
        {
            SceneReset();
            sceneReset = false;
        }
    }

    void LebenAbziehen()
    {
        aktuelleLeben--;
        lebenGlobal = aktuelleLeben; // Globale Leben aktualisieren

        if (aktuelleLeben > 0)
        {
            GameOverPunkte.punkteGlobal = 0; // Punkte zurücksetzen
        }
    }

    void AktualisiereHerzAnzeige()
    {
        // Alte Herzbilder löschen
        foreach (GameObject herzBildObj in GameObject.FindGameObjectsWithTag(herzBildTag))
        {
            Destroy(herzBildObj);
        }

        // Neue Herzbilder erstellen
        for (int i = 0; i < aktuelleLeben; i++)
        {
            Image anzeigeBild = Instantiate(herzBild, canvas.transform);
            anzeigeBild.tag = herzBildTag;

            // Position relativ zum Prefab-Bild setzen
            RectTransform rt = anzeigeBild.GetComponent<RectTransform>();
            Vector2 startPos = herzBild.rectTransform.anchoredPosition;
            rt.anchoredPosition = new Vector2(startPos.x + i * 71, startPos.y);
        }
    }

    void GameOver()
    {
        gameOverGeladen = true;
        SceneManager.LoadScene(gameOverSzene);
    }

    public void SceneReset()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);

        // Punkte zurücksetzen
        GameOverPunkte.punkteGlobal = 0; 

        // Leben zurücksetzen
        aktuelleLeben = 5; 
        lebenGlobal = aktuelleLeben; 
        AktualisiereHerzAnzeige(); 

        // Alle Timer zurücksetzen
        startZeit = Time.time; 
        zeitGlobal = 120f;

        // Reset für das nächste Spiel
        gameOverGeladen = false; 

        // Spielerobjekt zerstören, falls vorhanden
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}