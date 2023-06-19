using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int startingLives;
    public int lifeCounter;
    private Text lifeText;
    public GameObject gameOverScreen;
    public GameObject player;
    public Animator skeletonAnimator;
    public Animator skinAnimator;
    public PlayerMovement character;


    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<Text>();

        lifeCounter = startingLives;

        gameOverScreen.SetActive(false);

        character = FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (lifeCounter > 0)
        {
            lifeText.text = "x " + lifeCounter;
        }
        else
        {
            //player.SetActive(false);
            gameOverScreen.SetActive(true);
        }

    }

    public void LoseLife()
    {
        lifeCounter--;
    }

    public void TimeUp()
    {
        skeletonAnimator.SetBool("Melt", true);
        skinAnimator.SetBool("Melt", true);
        character.melt = true;
        lifeCounter -= startingLives;
    }
}
