﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSTOLAvatarMovement : MonoBehaviour
{
    [Tooltip("The axis on the controller you're gonna use for moving around. Look at the ProjectSettings panel's Input for this")]
    public Input inputDevice;
    public Transform avatar;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    [Tooltip("Valid options are left and right. Case sensitive.")]
    public string hand;
    private Transform forwardDirection;
    float yRotation;

    void Start()
    {
        forwardDirection = avatar.transform.Find("Head").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ovrinput = new Vector2(); // = new Vector2(0,0);
        // assume it's an oculus controller
        //float translation = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") * speed;
        switch (hand)
        {
            case "right":
                ovrinput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
                break;
            case "left":
                ovrinput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
                break;
        }



        // Make it move 10 meters per second instead of 10 meters per frame...
        Vector2 scaledOvrinput = ovrinput * speed * Time.deltaTime;
        float xAxis = scaledOvrinput.x;
        float yAxis = scaledOvrinput.y;

        //rotation *= Time.deltaTime;
        //float rotation = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * rotationSpeed;
        //if (ovrinput != new Vector2() && ovrinput != new Vector2())
        //{
        //    Debug.Log("got x and y axis for " + hand + " hand controller: " + new Vector3(0f, xAxis, yAxis).ToString());
        //}

        // Move translation along the object's z-axis
        yRotation = Time.deltaTime * forwardDirection.transform.rotation.eulerAngles.y;
        //avatar.rotation.eulerAngles.y = Quaternion.Euler(0, yRotation, 0);
        avatar.SetPositionAndRotation(new Vector3(xAxis, 0f, yAxis), forwardDirection.transform.rotation);
        //yAxis += Time.deltaTime * 10;
        //xAxis += Time.deltaTime * 10;
        avatar.transform.Translate(xAxis, 0f, yAxis);

        ovrinput = new Vector2();
    }
}
