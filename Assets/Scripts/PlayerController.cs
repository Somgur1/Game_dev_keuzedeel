using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // Create public variables for player speed, and for the Text UI game objects
    public float speed = 5.0f;
    public float jumpSpeed = 500f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public Transform orientation;

    public float jumpforce = 10f;
    bool canJump;
    Vector3 moveDirection;
    public float horizontalSpeed = 2.0F;

    private Rigidbody rb;
    private int count;

    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;

        // Set the count to zero 
        count = 0;

        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canJump = false;
        }
    }

    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above

        moveDirection = orientation.forward * Input.GetAxis("Vertical") + orientation.right * Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        //rb.AddForce(movement * speed, ForceMode.Force);

        if (Input.GetKey(KeyCode.Space) & canJump)
        {
            rb.AddForce(0f, jumpSpeed * Time.deltaTime, 0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 6)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
    }
}
