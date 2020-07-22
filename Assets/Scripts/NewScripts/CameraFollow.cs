using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed; //higher the float the faster it will lock to target (0-1)

    public Transform camPoint;

    public Vector3 offset, offsetRot,offsetRotQuat;

    public void Start()
    {
        //smoothSpeed = 0.8f;
    }


    public void FixedUpdate()//run right after update (after movement)
    {
        follow2();
    }

    void follow1()
    {
        Vector3 desiredPos = target.position + offset;
        //Vector3 desiredRot = target.eulerAngles + offsetRot;

        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        //Vector3 smoothedRot = Vector3.Lerp(transform.eulerAngles, desiredRot, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPos;
        //transform.eulerAngles = smoothedRot;
        transform.rotation = target.rotation;
        transform.LookAt(target);
    }


    void follow2()
    {
        Vector3 DesiredPos = camPoint.position;

        //Vector3 DesiredRot = camPoint.eulerAngles;// + offsetRot;
        //print(DesiredRot);

        Vector3 smoothPos = Vector3.Lerp(transform.position, DesiredPos, smoothSpeed * Time.deltaTime);

        //Vector3 smoothRot = Vector3.Lerp(transform.eulerAngles, DesiredRot, smoothSpeed * Time.deltaTime);

        //Vector3 euler = transform.eulerAngles;//new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        //Vector3 level = new Vector3(target.eulerAngles.x, target.eulerAngles.y, target.eulerAngles.z);
        //print(level);
        Vector3 smoothLevel = Vector3.Lerp((transform.eulerAngles), (target.eulerAngles + offsetRot), smoothSpeed * Time.deltaTime);

        //if (transform.eulerAngles.z != 180)
        //{
        //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180f);
        //}


        transform.position = smoothPos;
        //transform.eulerAngles = smoothLevel;
        //transform.eulerAngles = (new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,transform.eulerAngles.z)) + offsetRot;



        Quaternion rot = Quaternion.Euler(offsetRot.x,offsetRot.y,offsetRot.z); //convert offset to Quaternion then multiply instead of add to do offset
        transform.rotation = Quaternion.Slerp(transform.rotation, (target.rotation * rot), smoothSpeed * Time.deltaTime); //








        //transform.LookAt(target); //dont use
    }
}

//private void donotuse()
//{
//    [Header("Target")]
//public Transform target;

//[Space]

//[Header("Offset")]
//public Vector3 offset = Vector3.zero;

//[Space]

//[Header("Limits")]
//public Vector2 limits = new Vector2(5, 3);

//[Space]

//[Header("Smooth Damp Time")]
//[Range(0, 1)]
//public float smoothTime;

//private Vector3 velocity = Vector3.zero;

//void Update()
//{
//    //if (!Application.isPlaying)
//    //{
//    //transform.localPosition = offset;
//    //}

//    FollowTarget(target);
//}

//void LateUpdate()
//{
//    Vector3 localPos = transform.localPosition;

//    transform.localPosition = new Vector3(Mathf.Clamp(localPos.x, -limits.x, limits.x), Mathf.Clamp(localPos.y, -limits.y, limits.y), localPos.z);
//}

//public void FollowTarget(Transform t)
//{
//    Vector3 localPos = transform.localPosition;
//    Vector3 targetLocalPos = t.transform.localPosition;
//    transform.localPosition = Vector3.SmoothDamp(localPos, new Vector3(targetLocalPos.x + offset.x, targetLocalPos.y + offset.y, localPos.z), ref velocity, smoothTime);
//}

//    //private void OnDrawGizmos()
//    //{
//    //    Gizmos.color = Color.green;
//    //    Gizmos.DrawLine(new Vector3(-limits.x, -limits.y, transform.position.z), new Vector3(limits.x, -limits.y, transform.position.z));
//    //    Gizmos.DrawLine(new Vector3(-limits.x, limits.y, transform.position.z), new Vector3(limits.x, limits.y, transform.position.z));
//    //    Gizmos.DrawLine(new Vector3(-limits.x, -limits.y, transform.position.z), new Vector3(-limits.x, limits.y, transform.position.z));
//    //    Gizmos.DrawLine(new Vector3(limits.x, -limits.y, transform.position.z), new Vector3(limits.x, limits.y, transform.position.z));
//    //}
//}
