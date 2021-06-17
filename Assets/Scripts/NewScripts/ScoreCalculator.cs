using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    public TMP_Text score;
    public float points;
    public float maxTimeMins = 3;
    //public GameObject time;


    // Start is called before the first frame update
    void Start()
    {
        maxTimeMins = maxTimeMins * 60;
        if (points == null)
        {
            points = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + points.ToString("F2");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            points += 100;
        }
    }

    public void addscore(float time, float normalPoints)
    {
        float newTime = maxTimeMins - time;
        float newPoints = newTime* normalPoints;

        points += newPoints;
        print(newPoints);
    }
}
