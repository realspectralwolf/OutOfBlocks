using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsData : MonoBehaviour
{
    public static RoundsData Instance;
    public static int[] roundsWon = { 0, 0 };

    void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddRoundWon(bool isPlayerRight)
    {
        if (isPlayerRight)
        {
            roundsWon[1]++;
        }
        else
        {
            roundsWon[0]++;
        }
    }

    public int GetRoundsWon(bool isPlayerRight)
    {
        if (isPlayerRight)
        {
            return roundsWon[1];
        }
        else
        {
            return roundsWon[0];
        }
    }
}
