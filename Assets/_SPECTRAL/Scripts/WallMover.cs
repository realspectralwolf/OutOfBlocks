using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallManager : MonoBehaviour
{
    [SerializeField] private float timer = 0;
    public bool didGameEnd = false;
    [SerializeField] GameObject endScorePanel;
    public static System.Action RoundEnded;
    public bool canPlayersMove = true;

    IEnumerator EndingRound()
    {
        /*if (leftPointTrigger.points > rightPointTrigger.points)
        {
            PlayerPrefs.SetInt("rightplayer", PlayerPrefs.GetInt("rightplayer") + 1);
            endWallAnimator.Play("EndLeft");
            endScorePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-480, 0);
        }
        if (leftPointTrigger.points < rightPointTrigger.points)
        {
            PlayerPrefs.SetInt("leftplayer", PlayerPrefs.GetInt("leftplayer") + 1);
            endWallAnimator.Play("EndRight");
            endScorePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(480, 0);
        }
        if (leftPointTrigger.points == rightPointTrigger.points)
        {
            PlayerPrefs.SetInt("rightplayer", PlayerPrefs.GetInt("rightplayer") + 1);
            PlayerPrefs.SetInt("leftplayer", PlayerPrefs.GetInt("leftplayer") + 1);
            endWallAnimator.Play("EndAll");
        }
        finalLeft.text = PlayerPrefs.GetInt("leftplayer").ToString();
        finalRight.text = PlayerPrefs.GetInt("rightplayer").ToString();*/


        yield return new WaitForSeconds(3f); 
        AudioManager.Instance.PlaySmashed();
        endScorePanel.SetActive(true);

        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);


        print("end2");
        print(PlayerPrefs.GetInt("leftplayer"));
        /*finalLeft.text = PlayerPrefs.GetInt("leftplayer").ToString();
        finalRight.text = PlayerPrefs.GetInt("rightplayer").ToString();*/
    }
}
