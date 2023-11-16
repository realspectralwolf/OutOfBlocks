using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallMover : MonoBehaviour
{
    [SerializeField] public Transform leftWall;
    [SerializeField] public Transform rightWall;
    [SerializeField] private Animator endWallAnimator;
    [SerializeField] private FilledCenterLine centerLineFilled;
    public float time = 3;
    public PointCounter leftPointTrigger;
    public PointCounter rightPointTrigger;

    public TextMeshProUGUI finalLeft;
    public TextMeshProUGUI finalRight;
    public float timeLimit = 60;

    public float timer = 0;

    Vector3 startLeft;
    Vector3 startRight;

    Vector3 endLeft;
    Vector3 endRight;

    public static WallMover Instance;

    public bool didGameEnd = false;
    [SerializeField] GameObject endScorePanel;
    public static System.Action RoundEnded;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startLeft = Vector3.right * (-24f);
        startRight = Vector3.right * 24f;

        endLeft = Vector3.right * (-15f);
        endRight = Vector3.right * 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (didGameEnd) return;

        if (timer > 60)
        {
            didGameEnd = true;
            StartCoroutine(EndingRound());
            RoundEnded?.Invoke();
            return;
        }

        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        leftWall.position = Vector3.Lerp(startLeft, endLeft, timer / time);
        rightWall.position = Vector3.Lerp(startRight, endRight, timer / time);
    }

    public bool canPlayersMove = true;

    IEnumerator EndingRound()
    {
        leftWall.GetComponent<SpriteRenderer>().enabled = false;
        rightWall.GetComponent<SpriteRenderer>().enabled = false;
        endWallAnimator.gameObject.SetActive(true);
        Instantiate(centerLineFilled);

        if (leftPointTrigger.points > rightPointTrigger.points)
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
        finalRight.text = PlayerPrefs.GetInt("rightplayer").ToString();


        yield return new WaitForSeconds(3f); 
        AudioManager.Instance.PlaySmashed();
        endScorePanel.SetActive(true);

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        print("end2");
        print(PlayerPrefs.GetInt("leftplayer"));
        finalLeft.text = PlayerPrefs.GetInt("leftplayer").ToString();
        finalRight.text = PlayerPrefs.GetInt("rightplayer").ToString();
    }
}
