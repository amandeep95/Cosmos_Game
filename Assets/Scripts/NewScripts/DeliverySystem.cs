using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    public string order; //order will be used by another script to provide the text of level order
    public GameObject dialogue, controls;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel()
    {
        //enable canvas componant on control canvas GO instead of activating the entire GO

        controls.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 1f;
        dialogue.gameObject.SetActive(false);

    }


}
