using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // Spawn x number of enemies 
        for (int i = 0; i < numToSpawn; i += 1)
        {
            Instantiate(enemy, getRandomSpawnPosition(), transform.rotation);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        // Give them y stats

        // Reset spawn time
        currSpawnTime = 0;
        isSpawning = false;

        yield return null;
    }

    // Math for this function https://stackoverflow.com/questions/4061576/finding-points-on-a-rectangle-at-a-given-angle
    private Vector3 getRandomSpawnPosition()
    {
        float angle = Mathf.Deg2Rad * Mathf.Round(Random.Range(0, 360));
        Vector3 topRightPoint = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight));
        Vector3 botLeftPoint = cam.ScreenToWorldPoint(new Vector3(0, 0));

        // Snap point to camera box
        float x = Mathf.Max(Mathf.Min(spawnRadius * Mathf.Cos(angle), topRightPoint.x), botLeftPoint.x);
        float y = Mathf.Max(Mathf.Min(spawnRadius * Mathf.Sin(angle), topRightPoint.y), botLeftPoint.y);

        return new Vector3(x, y);
    }
    #endregion
}
