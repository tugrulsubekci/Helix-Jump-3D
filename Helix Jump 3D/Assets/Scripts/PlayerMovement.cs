using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public int jumpForce;
    private bool isCollisionEntered = false;
    public float gravityMultiplier;

    private GameManager GameManager;

    public Slider gameProgressSlider;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -17.0f, 0);
        playerRigidbody = GetComponent<Rigidbody>();
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameProgressSlider.maxValue = (GameManager.currentLevel + 5) * 5 - 4;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameProgressSlider.value != gameProgressSlider.maxValue && -transform.position.y > gameProgressSlider.value)
        {
            gameProgressSlider.value = -transform.position.y;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!isCollisionEntered && !GameManager.gameOver && !GameManager.levelCompleted)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isCollisionEntered = true;
            Invoke(nameof(IsCollisionEntered),0.2f);
            string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
            FindObjectOfType<AudioManager>().Play("Bounce");

            if (materialName == "Safe (Instance)")
            {

            }
            else if (materialName == "Unsafe (Instance)")
            {
                GameManager.gameOver = true;
                FindObjectOfType<AudioManager>().Play("GameOver");
            }
            else if( materialName == "Finish (Instance)")
            {
                GameManager.levelCompleted = true;
                FindObjectOfType<AudioManager>().Play("LevelCompleted");
            }
        }

    }

    private void IsCollisionEntered()
    {
        isCollisionEntered = false;
    }
}
