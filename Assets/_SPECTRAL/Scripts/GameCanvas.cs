using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Awake()
    {
        GetComponentInParent<MiniGameContainer>().GameCanvas = this;
    }

    public void UpdateScoreUI(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
