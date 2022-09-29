using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    #region Spawn Variables
    [Tooltip("Enemy to spawn")]
    public GameObject enemy;

    [Tooltip("How long in between spawn waves")]
    public float spawnTime = 1;
    private float currSpawnTime;

    private float spawnRadius = 15;

    [Tooltip("How many enemies to spawn per wave")]
    public float numToSpawn = 2;

    [Tooltip("How much time between each spawn in a wave")]
    public float timeBetweenSpawns = 0.5f;

    private bool isSpawning;

    [Tooltip("For testing")]
    public bool spawnImmediately;
    #endregion

    #region Scaling Variables
    [Tooltip("Initial range of spawning in degrees")]
    public int spawnRange;
    private float currOffset;
    private int gameStage;
    #endregion

    #region Spawing Calculation Variables
    private Camera cam;
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        currSpawnTime = 0;
        cam = Camera.main;
        if (spawnImmediately)
        {
            currSpawnTime = spawnTime;
        }
        gameStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currSpawnTime >= spawnTime && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnRoutine());
        } else
        {
            currSpawnTime += Time.deltaTime;
        }
    }
    #endregion

    #region Spawn Functions
    IEnumerator SpawnRoutine()
    {
        // Select and area to attack
        currOffset = Mathf.Round(Random.Range(0, 360 - spawnRange));

        // Spawn x number of enemies 
        for (int i = 0; i < numToSpawn; i += 1)
        {
            Instantiate(enemy, getRandomSpawnPosition(currOffset), transform.rotation);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        // Give them y stats

        // Reset spawn time
        currSpawnTime = 0;
        isSpawning = false;

        ScaleDifficulty();

        yield return null;
    }

    private Vector3 getRandomSpawnPosition(float offset)
    {
        
        return getRandomSpawnPositionRange(0 + offset, spawnRange + offset);
    }

    private Vector3 getRandomSpawnPositionAll()
    {
        return getRandomSpawnPositionRange(0, 360);
    }

    private Vector3 getRandomSpawnPositionRange(float lowerBound, float upperBound)
    {
        float angle = Mathf.Deg2Rad * Mathf.Round(Random.Range(lowerBound, upperBound));
        Vector3 topRightPoint = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight));
        Vector3 botLeftPoint = cam.ScreenToWorldPoint(new Vector3(0, 0));

        // Snap point to camera box
        float x = Mathf.Max(Mathf.Min(spawnRadius * Mathf.Cos(angle), topRightPoint.x), botLeftPoint.x);
        float y = Mathf.Max(Mathf.Min(spawnRadius * Mathf.Sin(angle), topRightPoint.y), botLeftPoint.y);

        return new Vector3(x, y);
    }
    #endregion

    public TextMeshProUGUI lvlText;
    #region Difficulty Scaling Functions
    private void ScaleDifficulty()
    {
        // # of enemies, time between spawns, range of target, time between waves (maybe happens later), hp of enemies
        int IDScale = Random.Range(0, 4);
        if ((int)Time.timeSinceLevelLoad / 30 > gameStage)
        {
            gameStage++;
            lvlText.text = "Level: " + (gameStage + 1);
            Statistics.enemyHealth *= 1.65f;
            spawnRange = Mathf.Min(360, spawnRange + 20);
            // Statistics.enemySpeed += 0.15f;
            // Statistics.enemyDamage *= 1.1f;
            spawnTime = 2 + 16f / (1 + gameStage);
            numToSpawn = gameStage / 1 + 2;
            Debug.Log(Time.timeSinceLevelLoad);
        }

        return;

        if (Time.timeSinceLevelLoad > 60 && gameStage == 0)
        {
            gameStage = 1;
            Statistics.enemyHealth = 2;
            spawnRange = 120;
            timeBetweenSpawns = 0.8f;
            spawnTime = 8;
        } else if (Time.timeSinceLevelLoad > 120 && gameStage == 1)
        {
            gameStage = 2;
            Statistics.enemyHealth = 4;
            spawnRange = 240;
            timeBetweenSpawns = 0.6f;
            Statistics.enemySpeed = 2;
            spawnTime = 6;
        } else if (Time.timeSinceLevelLoad > 180 && gameStage == 2)
        {
            gameStage = 3;
            Statistics.enemyHealth = 6;
            spawnRange = 360;
            timeBetweenSpawns = 0.4f;
            spawnTime = 4;
        } else if (Time.timeSinceLevelLoad > 240)
        {
            timeBetweenSpawns = 0.1f;
            Statistics.enemyHealth += 1;
            spawnTime = 3;
        } else if (Time.timeSinceLevelLoad > 360)
        {
            Statistics.enemyHealth += 1;
            spawnTime = 0;
        }
        numToSpawn += 2;

    }
    #endregion
}
