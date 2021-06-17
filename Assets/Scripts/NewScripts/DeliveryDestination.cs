using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryDestination : MonoBehaviour
{

    public GameObject player, scoreCanvas, timeCanvas;
    float currTime;
    //public TMP_Text score;
    public int PointsToAdd;
    
    //All public variables need to be declared in start method not inspector

    // Start is called before the first frame update
    void Start()
    {
        PointsToAdd = 10;

        player = GameObject.Find("Player");
        scoreCanvas = GameObject.Find("/Controls_UI/Score");
        timeCanvas = GameObject.Find("GameMaster");
        //score = GameObject.Find("sdf");

    }

    // Update is called once per frame
    void Update()
    {
        currTime = timeCanvas.GetComponent<LevelTimer>().CurrTimer;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            scoreCanvas.GetComponent<ScoreCalculator>().addscore(currTime,PointsToAdd); // addscore (time, points)
        }
    }
}
