﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;

    
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    Vector2 screenHalfSizeWorldUnits;


    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle), transform);
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }

}
