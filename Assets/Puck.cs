using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{

    public float strikeForce = 2.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Vector3 direction = input.normalized;
            Vector3 velocity = direction * strikeForce;
            this.GetComponentInParent<Rigidbody>().AddForce(velocity, ForceMode.Acceleration);




    }
}
