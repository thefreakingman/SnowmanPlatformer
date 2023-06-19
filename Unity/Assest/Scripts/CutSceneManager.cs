using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{

    public int duration;
    public int levelIndex;
    public Image blackScreen;
    public Animator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        CutSceneDuration();
    }

    // Update is called once per frame
    void Update()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void CutSceneComplete()
    {
        StartCoroutine(FadingCoroutine());
    }

    public IEnumerator FadingCoroutine()
    {
        fadeAnimator.SetBool("Fade", true);
        yield return new WaitUntil(() => blackScreen.color.a == 1);
        //SceneManager.LoadScene(levelIndex + 1);
    }

    public void CutSceneDuration()
    {
        StartCoroutine(CutSceneDurationCoroutine());
    }

    public IEnumerator CutSceneDurationCoroutine()
    {
        yield return new WaitForSeconds(duration);
        CutSceneComplete();
    }
}
