using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public int jumpForce;
    private bool isCollisionEntered = false;

    private GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isCollisionEntered && !GameManager.gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isCollisionEntered = true;
            Invoke("IsCollisionEntered",0.2f);
            string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
            if (materialName == "Safe (Instance)")
            {

            }
            else if (materialName == "Unsafe (Instance)")
            {
                GameManager.gameOver = true;
            }
            else if( materialName == "Finish (Instance)")
            {
                GameManager.levelCompleted = true;
            }
        }

    }

    private void IsCollisionEntered()
    {
        isCollisionEntered = false;
    }
}
