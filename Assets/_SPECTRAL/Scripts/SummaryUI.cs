using TMPro;
using UnityEngine;

public class SummaryUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI whoWinsText;
    public void SetTargetLostContainer(MiniGameContainer lostContainer)
    {
        if (lostContainer == null)
        {
            whoWinsText.text = "TIE";
            return;
        }
        Vector3 pos = Vector3.zero;
        pos.x = lostContainer.transform.position.x;
        transform.position = pos;

        string redHex = ColorToHex(GameManager.Instance.Settings.redColor);
        string blueHex = ColorToHex(GameManager.Instance.Settings.blueColor);

        string hex = lostContainer.isRight ? redHex : blueHex;
        string winner = lostContainer.isRight ? "RED" : "BLUE";

        whoWinsText.text = $"<color={hex}>{winner}<color=\"white\"> WINS!";
    }

    public static string ColorToHex(Color32 color)
    {
        string hex = "#" + color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
        return hex;
    }
}