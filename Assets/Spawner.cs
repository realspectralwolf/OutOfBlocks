using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float spawnTime = 3;
    public float powerUpTime = 13;
    public float timer = -1.35f;
    public float randomness = 2;
    public PowerUp powerup;
    [SerializeField] Sprite[] stoneSprites;

    Vector3 spawnPos = new Vector3(0, 8, 0);
    public Transform powerUpSpawn;
    float[] powerupTimers = { 0,0};
    private PowerUp[] existingPowerups = {null, null};

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.StartGameplayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime && WallMover.Instance.canPlayersMove)
        {
            timer = 0;

            SpawnCrate(1);
            SpawnCrate(-1);
        }

        PowerupTimerTick(0);
        PowerupTimerTick(1);
    }

    void SpawnCrate(int dir)
    {
        var prefab = prefabs[Random.Range(0, prefabs.Length)];

        float max = Mathf.Lerp(8.32f, 0f, WallMover.Instance.timer / WallMover.Instance.time);
        Vector3 pos = spawnPos + dir * Vector3.right * Random.Range(-0.82f, -max);
        var newCrate = Instantiate(prefab, pos, Quaternion.identity, transform);
        //newCrate.transform.localScale = Vector3.one * Random.Range(0.86f, 1.2f);
    }

    private void PowerupTimerTick(int i)
    {
        if (existingPowerups[i] == null)
        {
            powerupTimers[i] += Time.deltaTime;
        }
        else
        {
            return;
        }
        
        if (powerupTimers[i] >= powerUpTime && WallMover.Instance.canPlayersMove)
        {
            var prefab = powerup;
            powerupTimers[i] = 0;
            float max = Mathf.Lerp(7.2f, 0f, WallMover.Instance.timer / WallMover.Instance.time);
            Vector3 pos = powerUpSpawn.position - (Vector3.right * Random.Range(-0.82f, -max)) * (i*2-1);
            existingPowerups[i] = Instantiate(prefab, pos, Quaternion.identity, transform);
            existingPowerups[i].sideId = i;
        }
    }
}
