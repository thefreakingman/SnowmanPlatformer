using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    public CharacterController2D gamePlayer;
    public int snowballs;
    public Text scoreText;
    private LifeManager lifeSystem;
    public GameObject chest;
    public int levelIndex;
    public Image blackScreen;
    public Animator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<CharacterController2D>();
        lifeSystem = FindObjectOfType<LifeManager>();
        scoreText.text = "Score: " + snowballs;
    }

    // Update is called once per frame
    void Update()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Respawn()
    {
        // call the respawn co-routine to ensure that the respawn delay doesn't pause all other code
        if (lifeSystem.lifeCounter > 0)
        {
            StartCoroutine("RespawnCoroutine");
        }
    }

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        lifeSystem.LoseLife();
        gamePlayer.gameObject.SetActive(true);
        gamePlayer.jumpCount = 0;
    }

    public void AddSnowballs(int numberOfSnowballs)
    {
        snowballs += numberOfSnowballs;
        scoreText.text = "Score: " + snowballs;
    }

    public void LevelComplete()
    {
        StartCoroutine(FadingCoroutine());
    }

    public IEnumerator FadingCoroutine()
    {
        fadeAnimator.SetBool("Fade", true);
        yield return new WaitUntil(() => blackScreen.color.a == 1);
        SceneManager.LoadScene(levelIndex + 1);
    }
}
