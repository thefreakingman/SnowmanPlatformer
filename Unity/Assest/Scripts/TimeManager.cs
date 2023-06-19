using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public float startTemp;
    public float currentTime;
    public float maxTemp;
    public float maxTime;
    public float deltaTemp;
    public Slider tempBar;
    public LifeManager lifeSystem;
    public float lerpSpeed;
    public SpriteRenderer background;
    public Color startColor;
    public Color endColor;
    private float startTime;
    private float transitionTime;

    private Text tempText;

    // Start is called before the first frame update
    void Start()
    {
        tempText = GetComponent<Text>();

        tempBar.value = CalculateTemp();

        deltaTemp = maxTemp - startTemp;
        maxTime = currentTime + deltaTemp;

        startTime = Time.time;
    }

    float CalculateTemp()
    {
        return currentTime / maxTime;
    }

    // Update is called once per frame
    void Update()
    {

        lerpSpeed = maxTime / 10000;

        startTemp += Time.deltaTime;
        currentTime += Time.deltaTime;

        if (currentTime < maxTime)
        {
            tempText.text = Mathf.Round(startTemp) + " F";
            tempBar.value = CalculateTemp();
        }

        if (startTemp > maxTemp)
        {
            lifeSystem.TimeUp();
        }

        transitionTime = (Time.time - startTime) * lerpSpeed;
        background.GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, transitionTime);
        

    }

    public void DecreaseTemp(float tempAmount)
    {
        startTemp -= tempAmount;
        currentTime -= tempAmount;
    }
}
