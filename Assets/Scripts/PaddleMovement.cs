using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D _rigidbody2D;
    public float speed;
    private float movement;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (gameManager.GetGameState() == GameState.Gameplay)
        {
            Vector2 delta = new Vector2(movement*Time.fixedDeltaTime*speed, 0);
            _rigidbody2D.MovePosition(_rigidbody2D.position+delta);
        }
    }
}
