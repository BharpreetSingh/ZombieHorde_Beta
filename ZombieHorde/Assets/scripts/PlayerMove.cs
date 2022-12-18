using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public GameObject PlayerRotate;
    public Camera playercam;

    private CharacterController controller;
    public float playerSpeed;
    public float _rotationSpeed = 270;
    public float playerVelocity;

    public static int collectedItems = 0;

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        //takes the mouse position on screen and finds the position in world space
        mouse_pos = Input.mousePosition;
        object_pos = playercam.WorldToScreenPoint(PlayerRotate.transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;

        //takes the angle between the player and mouse world position, converts it to degrees from radiants 
        angle = Mathf.Atan2(mouse_pos.x, mouse_pos.y) * Mathf.Rad2Deg;

        //rotates the player asset towards the mouse position
        PlayerRotate.transform.rotation = Quaternion.Euler(0, angle, 0);

        // takes horizontal and vertical input and applys to the vector 3 move
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime, playerVelocity, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);

        // takes the move vector 3 and uses unity's character controller to move the player in the move vector 3 direction, also applying player speed
        controller.Move(move * playerSpeed);

        //Checks if playwer in on the ground if not applies gravity 
        if (controller.isGrounded)
        {
            playerVelocity = 0f;
        }
        else { playerVelocity = -0.005f; }
    }

}