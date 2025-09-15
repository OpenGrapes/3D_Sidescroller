using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighscoreManager : MonoBehaviour
{
    public List<ScoreEintrag> highscoreListe = new List<ScoreEintrag>();
    private string pfad;

    void Awake()
    {
        pfad = Path.Combine(Application.persistentDataPath, "highscore.dat");
        HighscoreLaden();
    }

    public void HighscoreSpeichern()
    {
        highscoreListe.Sort();
        var bf = new BinaryFormatter();
        using (var file = File.Create(pfad))
        {
            bf.Serialize(file, highscoreListe);
        }
    }

    public void HighscoreLaden()
    {
        if (File.Exists(pfad))
        {
            var bf = new BinaryFormatter();
            using (var file = File.Open(pfad, FileMode.Open))
            {
                highscoreListe = bf.Deserialize(file) as List<ScoreEintrag>;
            }
        }
    }

    public void VersucheHighscoreEintrag(int neuePunkte)
    {
        string name = PlayerPrefs.GetString("Spielername", "");

        if (string.IsNullOrEmpty(name)) return;

        var existierend = highscoreListe.Find(e => e.name == name);

        if (existierend != null)
        {
            if (neuePunkte > existierend.punkte)
                existierend.punkte = neuePunkte;
            else
                return;
        }
        else if (neuePunkte >= 100)
        {
            highscoreListe.Add(new ScoreEintrag(name, neuePunkte));
        }
        else
        {
            return;
        }

        HighscoreSpeichern();
    }
}
