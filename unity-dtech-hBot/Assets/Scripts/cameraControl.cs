using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    //Private Variables
    private float speed = 500.0f;
    private float turnSpeed = 35.0f;
    private float horizontalInput;
    private float forwardInput;
    private float horizontalSlideInput;
    private float verticalSlideInput;
    public Vector3 startingPosition;
    public Quaternion startingRotation;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {

        //Player Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        horizontalSlideInput = Input.GetAxis("hSlide");
        verticalSlideInput = Input.GetAxis("sSlide");

        // We''ll move the vehicle forward
        //transform.Translate(0,0,1);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * horizontalSlideInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * verticalSlideInput);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        
    }
}
