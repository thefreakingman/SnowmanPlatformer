using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private LevelManager gameLevelManager;
    public TimeManager tempManager;
    public int snowballValue;

    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
        tempManager = FindObjectOfType<TimeManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameLevelManager.AddSnowballs(snowballValue);
            tempManager.DecreaseTemp(snowballValue);
            Destroy(gameObject);
        }
    }
}
