using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILivesDisplay : MonoBehaviour
{
    private int displayedLives;
    public GameManager gameManager;
    public GameObject lifeDisplayPrefab;
    
    public void DisplayLives(int lives)
    {
        if (lives != displayedLives)
        {
            //clear children
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            //Create new children
            for (int i = 0; i < lives; i++)
            {
                Instantiate(lifeDisplayPrefab, transform);
            }
            displayedLives = lives;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //todo: event system
         DisplayLives(gameManager.GetLives());
    }
}
