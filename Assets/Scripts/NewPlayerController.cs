using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpAmount = 10;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;
    public TextMeshProUGUI TimeText;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool isTimerOn = false;
    private float time;
    private bool gameCompleted = false;
    public float drag;

    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    public float jumpforce = 10f;
    public bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

        if (gameCompleted == false && isTimerOn == false)
        {
            isTimerOn = true;
        }


    }





    void Update()
    {

        rb.drag = drag;

    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }




}
