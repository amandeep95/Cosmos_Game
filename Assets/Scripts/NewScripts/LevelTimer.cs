using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TMP_Text time;
    public float timer, CurrTimer;

    bool timerrunning;


    // Start is called before the first frame update
    void Start()
    {
        timerrunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerrunning)
        {
            StartTimer();
        }


        if (Input.GetKey(KeyCode.O))
        {
            timerrunning = true;
        }

        if (Input.GetKey(KeyCode.P))
        {
            timerrunning = false;
        }

        //if (Input.GetKey(KeyCode.P))
        //{
        //    StopTimer();
        //}
    }

    void StartTimer()
    {
        timer += Time.deltaTime;
        time.text = timer.ToString("F2");
        CurrTimer = timer;
    }

    void StopTimer()
    {
        timer = CurrTimer;
    }
}
