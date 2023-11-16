using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTextUpdater : MonoBehaviour
{
    [SerializeField] bool isRight = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = RoundsData.Instance.GetRoundsWon(isRight).ToString();
    }
}
