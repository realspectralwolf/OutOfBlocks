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

        RoundsData.Instance.IncrementTotalRounds();

        MiniGameContainer losingContainer = GetGameContainerWithWorstScore();
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

            foreach (var gameContainer in gameContainers)
            {
                if (gameContainer != losingContainer)
                {
                    RoundsData.Instance.AddRoundWon(gameContainer.isRight);
                }
            }   
        }

        AudioManager.Instance.PlayAudioClip(Settings.smashClip);

        var summaryPanel = Instantiate(Settings.summaryUI, Vector3.zero, Quaternion.identity);
        summaryPanel.SetTargetLostContainer(losingContainer);

        yield return new WaitForSecondsRealtime(Settings.timeBetweenRounds);        
        SceneManager.OpenGameplayScene();
    }

    private MiniGameContainer GetGameContainerWithWorstScore()
    {
        if (gameContainers[0].Counter.score == gameContainers[1].Counter.score) // tie
            return null;

        if (gameContainers[0].Counter.score > gameContainers[1].Counter.score)
        {
            return gameContainers[0];
        }
        else
        {
            return gameContainers[1];
        }
    }

    public float GetNormalizedTimePassed()
    {
        return timePassed / Settings.roundTime;
    }

    public AudioClip GetMusicTrack()
    {
        return Settings.music[RoundsData.Instance.GetTotalRounds() % Settings.music.Length];
    }
}
