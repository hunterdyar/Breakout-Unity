using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawnLocation;
    private GameState gameState;
    public int totalLives;
    private int lives;
    
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Gameplay;
        lives = totalLives;
        SpawnInNewBall();
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public int GetLives()
    {
        return lives;
    }
    
    //Called by the ball when it goes into the death zone.
    public void BallGoneOffScreen()
    {
        lives--;
        if (lives == 0)
        {
            gameState = GameState.GameOver;
        }
        SpawnInNewBall();
    }

    //called by the brick when one is destroyed
    public void BrickDestroyed()
    {
        Brick[] bricks = GameObject.FindObjectsOfType<Brick>();
        if (bricks.Length <= 1)
        {
            gameState = GameState.Victory;
            //find and destroy the last ball
            
            //gameManager -> uiManager
            // uiManager -> gameManager
        }
    }

    private void SpawnInNewBall()
    {
        if (gameState == GameState.Gameplay)
        {
            GameObject ballObject = Instantiate(ballPrefab, ballSpawnLocation.position, Quaternion.identity);
            Ball ball = ballObject.GetComponent<Ball>();
            ball.SetGameManager(this);
        }
    }
}
