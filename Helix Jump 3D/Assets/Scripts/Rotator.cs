using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float inputX;
    public float rotationSpeed;
    private GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !GameManager.gameOver)
        {
            inputX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * -inputX * rotationSpeed * Time.deltaTime);
        }
    }
}
