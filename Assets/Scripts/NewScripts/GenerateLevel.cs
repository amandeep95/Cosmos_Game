using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject neighbourhood;
    public Transform Base;
    public int maxPlatforms;// = 15;
    public int deliveries;

    private List<GameObject> platforms = new List<GameObject>();
    public GameObject plat1, plat2, plat3, plat4;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = Base.transform.position;

        platforms.Add(plat1);
        platforms.Add(plat2);
        platforms.Add(plat3);
        platforms.Add(plat4);

        maxPlatforms = Random.RandomRange(15, 20);

        for (int i = 0; i < maxPlatforms; i++)
        {
            makeNewPlatform(i);
            
            print("loop");
        }
        //Destroy(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //for (int i = 0; i < maxPlatforms; i++)
        //{
        //    makeNewPlatform();
        //    print("loop");
        //}
    }

    void makeNewPlatform(int i)
    {
        //int j = i;
        //if (platforms[i-1].position.x != null) {
        float yRot = Random.RandomRange(0, 360);
        float xPos = Random.RandomRange(Random.RandomRange(-700, -100), Random.RandomRange(100, 700));
        float yPos = Random.RandomRange(Random.RandomRange(-700, -100), Random.RandomRange(100, 700));
        float zPos = Random.RandomRange(Random.RandomRange(-700, -100), Random.RandomRange(100, 700));
        int platnum = Random.RandomRange(1,4);
        //Instantiate(platforms[i], new Vector3(xPos, yPos, zPos));//, platform[i].transform.rotation * new Vector3(0,yRot,0));
        Vector3 newPos = new Vector3(xPos, yPos, zPos);
        //GameObject plat = Instantiate(neighbourhood, newPos, Quaternion.Euler(0, yRot, 0));//, platform[i].transform.rotation * new Vector3(0,yRot,0));
        GameObject plat = Instantiate(platforms[platnum], newPos, Quaternion.Euler(0, yRot, 0));//, platform[i].transform.rotation * new Vector3(0,yRot,0));
        TurnonDelivery(plat, i);
        //print("new Platform made");
        //}
    }

    void TurnonDelivery(GameObject obj, int i)
    {
        //int num = Random.Range(1,2);
        if (i % 3 == 0 && deliveries != 0) //if number is even
        {
            obj.transform.GetChild(1).gameObject.SetActive(true);
            deliveries--;
        }
    }


    //public struct Platform
    //{
    //    public Vector3 position;

    //    public Platform(Vector3 pos)
    //    {
    //        position = pos;
    //    }
    //}
}
