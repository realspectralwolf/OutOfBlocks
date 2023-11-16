using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    public float roundTime = 56;
    public float timeBetweenRounds = 5;
    public float crateSpawnHeight = 10;
    public float powerupSpawnHeight = 10;
    public float crateSpawnTime = 3;
    public float powerupSpawnTime = 12;
    public float finishAnimTime = 0.3f;
    public GameObject finishParticles;
    public Transform summaryUI;

    public Range crateSpawnOuterLimit;
    public float crateSpawnInnerLimit;
}