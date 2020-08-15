using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms; //index 0 --> LR, index 1 --> LRB, index 2 --> LRT, index 3 --> LRTB

    private int direction;
    public float moveAmount;

    private float timeBtwRoom;
    public float startTimeBtwRoom;// = 0.25f;

    public float minX;
    public float maxX;
    public float minY;
    public bool stopGeneration;

    public LayerMask room;

    private int downCounter;

    // Start is called before the first frame update
    void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        //if (timeBtwRoom <= 0 && stopGeneration == false)
        //{
        //    Move();
        //    timeBtwRoom = startTimeBtwRoom;
        //} else
        //{
        //    timeBtwRoom -= Time.deltaTime;
        //}
        Move();
    }

    private void Move()
    {
        if (direction == 1 || direction == 2)//move right
        {
            downCounter = 0;

            //check if pos of spawn is at the end, if its less then make room
            if (transform.position.x < maxX)
            {

                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                //set direction value to only let it go right again or down
                direction = Random.Range(1, 6);
                if (direction == 3)//if value is to move left then movbe right or down
                {
                    direction = 2;
                }
                else if (direction == 4)
                {
                    direction = 5;
                }

            }
            else
            {
                direction = 5;//move DOWN if the max is reached (if its on the right)
            }


        }
        else if (direction == 3 || direction == 4)//move left
        {
            downCounter = 0;

            if (transform.position.x > minX) //check if its on the max left otherwise move down
            {
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);//only go left or down


            }
            else
            {
                direction = 5;
            }



        }
        else if (direction == 5)//move down
        {
            downCounter++;

            if (transform.position.y > minY)
            {

                Collider2D roomDetector = Physics2D.OverlapCircle(transform.position, 1, room);

                //if (roomDetector.GetComponent<RoomType>().type != 1 && roomDetector.GetComponent<RoomType>().type != 3) //if room dowsnt have a bottom opeing
                //{// 1 and 3

                //    if (downCounter >= 2)
                //    {
                //        //make room with opening in ALL direction
                //        //roomDetector.GetComponent<RoomType>().RoomDestroy();
                //        Instantiate(rooms[3], transform.position, Quaternion.identity);
                //    }
                //    else
                //    {
                //        roomDetector.GetComponent<RoomType>().RoomDestroy();

                //        int randBottomRoom = Random.Range(1, 4); //1 - 3
                //        if (randBottomRoom == 2)
                //        {
                //            randBottomRoom = 1;
                //        }
                //        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                //    }



                //}

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4); //2 and 3 have TOP OPENINGS
                Instantiate(rooms[rand], transform.position, Quaternion.identity);


                direction = Random.Range(1, 6);//can go left,right or down

            }
            else
            {
                //STOP LEVEL GENERATION CUS IT CANT MOVE DOWN ANYMORE
                stopGeneration = true;
            }


        }

        //Instantiate(rooms[0], transform.position, Quaternion.identity);
        //direction = Random.Range(1, 6);
    }
}
