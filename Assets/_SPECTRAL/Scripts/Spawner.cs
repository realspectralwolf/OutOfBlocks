using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public PowerUp powerupPrefab;
    public float randomness = 2;

    private float timeLeftToSpawn, timeLeftToPowerup;
    private PowerUp existingPowerup = null;

    private float flipFactor = 1;

    private void Awake()
    {
        GetComponentInParent<MiniGameContainer>().Spawner = this;

        if (GetComponentInParent<MiniGameContainer>().isRight)
        {
            flipFactor = 1;
        }
        else
        {
            flipFactor = -1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeLeftToSpawn = GameManager.Instance.Settings.crateSpawnTime;
        timeLeftToPowerup = GameManager.Instance.Settings.powerupSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeftToSpawn -= Time.deltaTime;
        if (timeLeftToSpawn <= 0)
        {
            timeLeftToSpawn = GameManager.Instance.Settings.crateSpawnTime;

            SpawnCrate();
        }

        //PowerupTimerTick(); Disabled powerup
    }

    private void SpawnCrate()
    {
        var prefab = prefabs[Random.Range(0, prefabs.Length)];


        Vector3 pos = Vector3.zero;
        pos.y = GameManager.Instance.Settings.crateSpawnHeight;
        pos.x = GetRandomX(margin: 0);

        Vector3 rot = Vector3.zero;
        rot.z = Random.Range(0, 3) * 90;

        Instantiate(prefab, pos, Quaternion.Euler(rot), transform);
    }

    private float GetRandomX(float margin){
        float t = GameManager.Instance.GetNormalizedTimePassed();
        float outerMin = GameManager.Instance.Settings.crateSpawnOuterLimit.min;
        float outerMax = GameManager.Instance.Settings.crateSpawnOuterLimit.max;
        float currentMax = Mathf.Lerp(outerMax, outerMin, t);

        float min = GameManager.Instance.Settings.crateSpawnInnerLimit;
        return flipFactor * Random.Range(min + margin, currentMax - margin);
    }

    private void PowerupTimerTick()
    {
        if (existingPowerup == null)
        {
            timeLeftToPowerup -= Time.deltaTime;
        }
        else
        {
            return;
        }
        
        if (timeLeftToPowerup <= 0)
        {
            var prefab = powerupPrefab;
            timeLeftToPowerup = GameManager.Instance.Settings.powerupSpawnTime;

            Vector3 pos = Vector3.zero;
            pos.y = GameManager.Instance.Settings.powerupSpawnHeight;
            pos.x = GetRandomX(margin: 1);
            existingPowerup = Instantiate(prefab, pos, Quaternion.identity, transform);
        }
    }
}
