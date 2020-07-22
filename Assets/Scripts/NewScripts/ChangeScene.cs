using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int scene;

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(scene);
    }
}
