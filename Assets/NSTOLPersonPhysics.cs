using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSTOLPersonPhysics : MonoBehaviour
{


    // The purpose of this is to take some tips from VRTK's BodyPhysics and implement it. Simple stuff like the person's body colliding with things. 
    private float personVerticalStartingPosition;
    private float allowedYThreshold = 1f; // how far are they allowed to move their head vertically (both up and down) before we reset it. In meters.
    [Tooltip("This limits squating and jumping, but prevents people from going flying over into the void and other weird stuff that can happen.")]
    public bool limitVerticalMovement = true;
    [Tooltip("VALUE VISIBLE FOR DEBUGGING ONYL: Should be set automatically. If it isn't, make sure you have a OVRCameraRig as a child of this avatar game object")]
    public OVRCameraRig VRRig;
    [Tooltip("VALUE VISIBLE FOR DEBUGGING ONYL: Should be set automatically. If it isn't, make sure you have a OVRCameraRig as a child of this avatar game object. That object should have a TrackingSpace Gameobject with a child CenterEyeAnchor camera")]
    public Transform personsEyes;



    private void Start()
    {
        VRRig = GetComponentInChildren<OVRCameraRig>();
        personsEyes = VRRig.transform.Find("TrackingSpace").transform.Find("CenterEyeAnchor");
        this.personVerticalStartingPosition = personsEyes.transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        if (this.limitVerticalMovement)
        {
            //this.limitHeadPosition();
        }
    }

    public virtual void isStanding()
    {

    }

    private void limitHeadPosition()
    {
        if (this.limitVerticalMovement)
        {
            float personVerticalPositionRightNow = personsEyes.position.y;   // y position of their head, right now.
            Vector2 personGroundPositionRightNow = new Vector3(personsEyes.position.x, personsEyes.position.z, 0f);
            float personVerticalChangeAmount = Mathf.Abs(this.personVerticalStartingPosition - personVerticalPositionRightNow); // how much their head has moved
            float personPositionMinVerticalPosition = personVerticalStartingPosition - this.allowedYThreshold;  // how low can you go?
            float personPositionMaxVerticalPosition = personVerticalStartingPosition + this.allowedYThreshold;  // how high can you fly?
            if (personVerticalChangeAmount > this.allowedYThreshold) // if they move their head vertically more than I allow, clamp their position.
            {
                // forcefully sets the position based on their current position, and the limited vertical variance allowed by the threshold value.
                /* 
                 * transform.position = new Vector3(personGroundPositionRightNow.x,
                    Mathf.Clamp(personVerticalPositionRightNow, personPositionMinVerticalPosition, personPositionMaxVerticalPosition),
                    personGroundPositionRightNow.y); 
                    */
                transform.position = new Vector3(5,0,0);
            }
        }
    } 
}
