using System;

[Serializable]
public class ScoreEintrag : IComparable
{
    public string name;
    public int punkte;

    public ScoreEintrag(string name, int punkte)
    {
        this.name = name;
        this.punkte = punkte;
    }

    public int CompareTo(object obj)
    {
        ScoreEintrag anderer = obj as ScoreEintrag;
        return anderer.punkte.CompareTo(this.punkte); // Höchste Punkte zuerst
    }
}
