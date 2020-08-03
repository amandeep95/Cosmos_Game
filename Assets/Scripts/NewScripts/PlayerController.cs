using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float force, baseForce;
    public float turnspeed;

    public bool mobile, pc, joystick, joystickAlt;
    public float multiplier;

    public GameObject pointingTo;

    float x, y, z;

    public float time = 10;
    public TMP_Text xAxis, yAxis, zAxis;


    private Vector3 appliedLinearForce = Vector3.zero;
    private Vector3 appliedAngularForce = Vector3.zero;

    public Joystick Hor, Ver, Acc, Steer;
    public float StabalizeSpeed;

    void Start()
    {
        //rb = transform.GetChild(0).GetComponent<Rigidbody>();//get rb of first child element
        rb = GetComponent<Rigidbody>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //Boost.onClick.AddListener(BoostPlayer);

        baseForce = force;
    }

    // Update is called once per frame
    void Update() //update for getting user input
    {
        if (mobile)
        {
            x = Input.acceleration.x;
            y = Input.acceleration.y;
            z = Input.acceleration.z;
        }
        if (pc)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxisRaw("Vertical");
        }
        if (joystick)
        {
            x = Hor.Horizontal;
            y = Ver.Vertical;
        }
        if (joystickAlt)
        {
            x = Steer.Horizontal;
            y = Steer.Vertical;
        }
    }

    void FixedUpdate() //update for physics detection
    {
        movement4(x, y, z);
        accelerate();
    }

    private void movement1(float x, float y, float z)
    {
        //Boost.onClick.AddListener(BoostPlayer);
        if (mobile)
        {
            ////rb.AddForce(0, 0, force); //continuously gains speed, do not use
            //rb.velocity = Vector3.forward * force; //works well
            //                                       //rb.MovePosition(rb.transform.position + (Vector3.forward * force * Time.deltaTime)); // works good but there is camera shaking, alot

            //float x = Input.acceleration.x;
            //float y = Input.acceleration.y;
            //float z = Input.acceleration.z;
            //rb.velocity = new Vector3((x * turnspeed), (z * turnspeed), force);

            //xAxis.text = "x: " + x;
            //yAxis.text = "y: " + y;
            //zAxis.text = "z: " + z;

            //print(force);
            //---------------------------------
            Vector3 dir = pointingTo.transform.position - rb.transform.position;
            rb.velocity = dir * force;//Vector3.forward * force;

            x = Input.acceleration.x;
            y = Input.acceleration.y;
            z = Input.acceleration.z;

            //rb.velocity = new Vector3(0, y * 10, force);

            //transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.x);
            rb.transform.Rotate(-z * multiplier, x * multiplier, 0);
        }

        if (pc)
        {
            Vector3 dir = pointingTo.transform.position - rb.transform.position;
            rb.velocity = dir * force;//Vector3.forward * force;

            x = Input.GetAxis("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            //rb.velocity = new Vector3(0, y * 10, force);

            //transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.x);
            rb.transform.Rotate(-y * multiplier, x * multiplier, 0);
        }
    }


    void movement2(float x, float y, float z)
    {
        //PC controls
        rb.AddTorque(transform.up * 5 * x); //turn car left and right
        rb.AddTorque(transform.right * 5 * y);//turn car up and down

    }

    void movement3(float x, float y, float z)
    {
        rb.AddRelativeForce(appliedLinearForce * 5, ForceMode.Force);
        rb.AddRelativeTorque(appliedAngularForce * 5, ForceMode.Force);
    }


    void movement4(float x, float y, float z)
    {
        rb.transform.Rotate((-y * multiplier) / 2, (x * multiplier) / 2, 0);

        xAxis.text = Acc.Vertical.ToString();

    }

    public void BoostPlayer()
    {
        force = force * 2;

    }

    public void NormalSpeed()
    {
        force = baseForce;
    }

    void accelerate()
    {
        //Vector3 dir = pointingTo.transform.position - rb.transform.position;
        //rb.velocity = transform.forward * Time.deltaTime * force;//Vector3.forward * force;
        float remapVal;

        if (Acc.Vertical <= -0.5f)
        {
            remapVal = -2;
        }
        else if (Acc.Vertical <= 0)
        {
            remapVal = 1.5f;
        }
        else if (Acc.Vertical <= 0.5f)
        {
            remapVal = 2f;
        }
        else
        {
            remapVal = 3.5f;
        }
        yAxis.text = remapVal.ToString();

        rb.velocity = transform.forward * Time.deltaTime * remapVal * force;
    }

    public void stabalize()
    {
        //Vector3 
        //Vector3 smoothLevel = Vector3.Lerp((transform.eulerAngles.z), 0, StabalizeSpeed * Time.deltaTime);
        //Quaternion rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0); //convert offset to Quaternion then multiply instead of add to do offset
        //transform.rotation = Quaternion.Slerp(transform.rotation, rot, StabalizeSpeed * Time.deltaTime); //


        //transform.rotation = Quaternion.Euler((transform.eulerAngles.x),(transform.eulerAngles.y),(Mathf.Lerp(transform.eulerAngles.z, 0f,0.5f)));

        Quaternion stable = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, stable, StabalizeSpeed * Time.deltaTime);
    }
}
