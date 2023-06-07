using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose
{
    public int winner;
    public int loser;

    public WinLose(int winner, int loser)
    {
        this.winner = winner;
        this.loser = loser;
    }
    public int getWinner()
    {
        return winner;
    }

    public void setWinner(int winner)
    {
        this.winner = winner;
    }

    public int getLoser()
    {
        return loser;
    }

    public void setLoser(int loser)
    {
        this.loser = loser;
    }
}
