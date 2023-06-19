using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{

    public LevelManager gameLevelManager;
    public GameObject gamePlayer;

    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //gamePlayer.gameObject.SetActive(false); 
            gameLevelManager.LevelComplete();
        }
    }
}
