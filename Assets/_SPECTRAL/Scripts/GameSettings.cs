using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [Header("Time")]
    public float roundTime = 56;
    public float timeBetweenRounds = 5;
    public float crateSpawnTime = 3;
    public float powerupSpawnTime = 12;
    public float finishAnimTime = 0.3f;
    public float initialCrateSpawnTime = 0.7f;

    [Header("Positioning")]
    public float crateSpawnHeight = 10;
    public float powerupSpawnHeight = 10;
    public Range crateSpawnOuterLimit;
    public float crateSpawnInnerLimit;

    [Header("Colors")]
    public Color32 redColor;
    public Color32 blueColor;

    [Header("Prefabs")]
    public GameObject finishParticles;
    public SummaryUI summaryUI;

    [Header("Audio")]
    public AudioClip smashClip;
    public AudioClip gateClosedClip;
    public AudioClip crateHit;
    public AudioClip[] music;
}