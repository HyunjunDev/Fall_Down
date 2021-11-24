using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject falingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;
    [SerializeField]
    private Vector2 spawnSizeMinMax;
    [SerializeField]
    private float spawnAngleMax;
    Vector2 screenHalfSizeWorldUnits;
    float timer;
    int waitingTime;
    private void Start()
    {
        timer = 0.0f;
        waitingTime = 2;
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            if (Time.time > nextSpawnTime)
            {
                float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
                print(secondsBetweenSpawns);
                nextSpawnTime = Time.time + secondsBetweenSpawns;
                float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
                float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
                Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
                var newBlock = ObjectPool.GetObject();
                //GameObject newBlock = (GameObject)Instantiate(falingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
                newBlock.transform.position = spawnPosition;
                newBlock.transform.rotation = Quaternion.Euler(Vector3.forward * spawnAngle);
                newBlock.transform.localScale = Vector2.one * spawnSize;
                newBlock.FalingBlock();
            }
        }
    }
}
