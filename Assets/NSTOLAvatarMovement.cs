using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSTOLAvatarMovement : MonoBehaviour
{
    [Tooltip("The axis on the controller you're gonna use for moving around. Look at the ProjectSettings panel's Input for this")]
    public Input inputDevice;
    public Transform avatar;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    private string hand = "left";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ovrinput = new Vector2(0,0);
        // assume it's an oculus controller
        //float translation = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") * speed;
        switch (hand)
        {
            case "right":
                ovrinput = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote);
                break;
            case "left":
                ovrinput = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.LTrackedRemote);
                break;
        }
        
        //float rotation = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * rotationSpeed;
        Debug.Log("got x and y axis for controller: [" + ovrinput.ToString() + "]");

        // Make it move 10 meters per second instead of 10 meters per frame...
        Vector2 scaledOvrinput = ovrinput * Time.deltaTime;
        Vector3 movementAmount = new Vector3(scaledOvrinput.x, scaledOvrinput.y);
        //rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(scaledOvrinput);

    }
}
