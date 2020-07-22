using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public bool joystick;
    private Transform playerModel;
    public float xySpeed;
    public float lookSpeed;
    public float forwardSpeed;

    public TMP_Text x, y, z;

    Gyroscope mobile;
    float currentPos;

    private CharacterController controller;

    Vector3 dir;

    public Button Boost;

    public Transform aimTarget;
    // Start is called before the first frame update
    void Start()
    {
        playerModel = transform.GetChild(0);
        //SetSpeed(forwardSpeed);

        mobile = Input.gyro;
        mobile.enabled = true;

        currentPos = Input.acceleration.z;

        Boost.onClick.AddListener(Boostplayer);
    }

    // Update is called once per frame
    void Update()
    {
        //float h = joystick ? Input.GetAxis("Horizontal") : Input.GetAxis("Mouse X");
        //float v = joystick ? Input.GetAxis("Vertical") : Input.GetAxis("Mouse Y");
        //float h = joystick ? Input.GetAxis("Horizontal") : Mathf.Clamp(mobile.rotationRate.y, -0.5f, 0.5f);
        //float v = joystick ? Input.GetAxis("Vertical") : Mathf.Clamp(mobile.rotationRate.x, -0.5f, 0.5f);


        //Vector3 moveVector = transform.forward * forwardSpeed;

        //Vector3 yaw = mobile.rotationRate.y * transform.right * Time.deltaTime;
        //Vector3 pitch = mobile.rotationRate.y * transform.up * Time.deltaTime;
        //Vector3 dir = yaw + pitch;

        //float maxX = Quaternion.LookRotation(moveVector + dir).eulerAngles.x;
        //controller.Move(moveVector * Time.deltaTime);



        //float h = joystick ? Input.GetAxis("Horizontal") : Input.acceleration.x;
        //float v = joystick ? Input.GetAxis("Vertical") : Mathf.Clamp(Input.acceleration.z, -10f, 10f);



        //dir.x = Input.acceleration.y; //dir X
        //dir.z = Input.acceleration.x; //dir Z

        Vector3 tilt = Input.acceleration;

        //tilt = Quaternion.Euler(-45,0,0) * tilt;

        //dir.x = tilt.y;
        //dir.z = tilt.x;

        dir.x = tilt.y;
        dir.y = tilt.z;

        //dir.x = Input.acceleration.x; //dir X
        //dir.y = Input.acceleration.z; //dir Z

        float h = dir.z;
        float v = dir.x;

        //display accleration angles to text
        x.text = "X: " + tilt.x.ToString("F2");
        y.text = "Y: " + tilt.y.ToString("F2");
        z.text = "Z: " + tilt.z.ToString("F2");

        ////MoveForward();
        //LocalMove(h, v, xySpeed);
        ////RotationLook(h, v, lookSpeed);
        //HorizontalLean(playerModel, h, 80, .1f);

    }

    void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
        //ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    //void RotationLook(float h, float v, float speed)
    //{
    //    aimTarget.parent.position = Vector3.zero;
    //    aimTarget.localPosition = new Vector3(h, v, 1);
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed * Time.deltaTime);
    //}

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
    }

    void FixedUpdate()
    {
        //playerModel.GetComponent<Rigidbody>().AddForce(transform.forward * forwardSpeed);
        //transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);


        //move player forward
        //dir.z = 1;
        playerModel.GetComponent<Rigidbody>().velocity = Vector3.forward * forwardSpeed;

        //move player
        //playerModel.GetComponent<Rigidbody>().velocity = dir * forwardSpeed;


        //transform.Translate(dir * forwardSpeed * Time.deltaTime);
    }

    void Boostplayer()
    {

    }
}
