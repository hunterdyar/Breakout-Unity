using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float launchSpeed;
    public float delayBeforeLaunchTime;
    
    private Rigidbody2D _rigidbody2D;
    private float timer;
    private GameManager _gameManager;//equal to something????
    private bool launched;
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        // FireInRandomDirection();
        launched = false;
        timer = 0;
    }

    void Update()
    {
        if (!launched)
        {
            timer += Time.deltaTime;
            if (timer >= delayBeforeLaunchTime)
            {
                FireInRandomDirection();
            }
        }
    }

    public void SetGameManager(GameManager manager)
    {
        _gameManager = manager;
    }
    //Fire in a random direction
    public void FireInRandomDirection()
    {
        //Get a random direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        while (Mathf.Abs(randomDirection.y) < 0.1f)
        {
            randomDirection = Random.insideUnitCircle.normalized;
        }

    //Apply it to the rigidbody
        _rigidbody2D.velocity = randomDirection*launchSpeed;
        launched = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _gameManager.BallGoneOffScreen();
        Destroy(gameObject);
    }
}
