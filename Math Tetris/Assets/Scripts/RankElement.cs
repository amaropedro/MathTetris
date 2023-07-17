using System;

[Serializable]
public class RankElement
{
    public string playerName;
    public int score;

    public RankElement(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}
