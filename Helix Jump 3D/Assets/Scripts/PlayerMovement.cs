using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public int jumpForce;
    private bool isCollisionEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isCollisionEntered)
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isCollisionEntered = true;
        Invoke("IsCollisionEntered",0.2f);
    }

    private void IsCollisionEntered()
    {
        isCollisionEntered = false;
    }
}
