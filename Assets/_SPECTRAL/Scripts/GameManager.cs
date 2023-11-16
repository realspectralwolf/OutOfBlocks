using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameSettings Settings;
    public float timePassed = 0;
    public static System.Action OnRoundFinished;

    [SerializeField] private MiniGameContainer[] gameContainers;
    private bool didRoundFinish = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AudioManager.Instance.StartGameplayMusic();
    }

    private void Update()
    {
        if (didRoundFinish) return;

        if (timePassed < Settings.roundTime){
            timePassed += Time.deltaTime;
        }
        else{
            StartCoroutine(HandleRoundFinish());
        }
    }

    private IEnumerator HandleRoundFinish()
    {
        didRoundFinish = true;
        OnRoundFinished?.Invoke();

        yield return new WaitForSecondsRealtime(1.5f);

        Vector3 pos = Vector3.zero;
        var losingContainer = GetGameContainerWithWorstScore();
        if (losingContainer == null) // tie
        {
            foreach (var gameContainer in gameContainers)
            {
                gameContainer.Wall.PlayFinishAnimation();
            }
        }
        else
        {
            losingContainer.Wall.PlayFinishAnimation();
            pos.x = losingContainer.transform.position.x;

            foreach (var gameContainer in gameContainers)
            {
                if (gameContainer != losingContainer)
                {
                    RoundsData.Instance.AddRoundWon(gameContainer.isRight);
                }
            }   
        }

        Instantiate(Settings.summaryUI, pos, Quaternion.identity);
        yield return new WaitForSecondsRealtime(Settings.timeBetweenRounds);
        SceneManager.OpenGameplayScene();
    }

    private MiniGameContainer GetGameContainerWithWorstScore()
    {
        MiniGameContainer highest = gameContainers[0];
        for (int i = 0; i < gameContainers.Length; i++) 
        {
            if (gameContainers[i].Counter.score > highest.Counter.score)
                highest = gameContainers[i];
        }

        if (gameContainers[0] == null) // tie
            return null;

        return highest;
    }

    public float GetNormalizedTimePassed()
    {
        return timePassed / Settings.roundTime;
    }
}
