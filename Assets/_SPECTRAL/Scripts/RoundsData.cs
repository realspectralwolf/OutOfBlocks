using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundsData : MonoBehaviour
{
    [SerializeField] public static RoundsData Instance { get; private set; }
    private int[] roundsWon = { 0, 0 };
    public int totalRounds = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

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

    public void IncrementTotalRounds()
    {
        totalRounds++;
    }

    public int GetTotalRounds()
    {
        return totalRounds;
    }
}
