using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject BrickPrefab;
    public GameManager gameManager;
    public int numberBricksAccross;
    public int numberBricksDown;
    public Vector2 separation;
    private void Awake()
    {
        SpawnBricks();
    }

    public void SpawnBricks()
    {
        for (int i = 0; i < numberBricksAccross; i++)
        {
            for (int j = 0; j < numberBricksDown; j++)
            {
                Vector3 position = transform.position + new Vector3(i * separation.x, -j * separation.y, 0);
                Brick brick = Instantiate(BrickPrefab, position, Quaternion.identity).GetComponent<Brick>();
                brick.SetGameManager(gameManager);
                brick.SetColor(j);
            }
        }
    }
}
