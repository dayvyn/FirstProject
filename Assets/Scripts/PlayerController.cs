using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    Camera mainCam;
    float forwardBack;
    float leftRight;
    Vector3 playerMoveVector;
    [SerializeField] float moveSpeed;
    [SerializeField] int jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        forwardBack = Input.GetAxis("Vertical");
        leftRight = Input.GetAxis("Horizontal");

        playerMoveVector = new Vector3(forwardBack * moveSpeed, playerRB.velocity.y, leftRight * moveSpeed);

        playerRB.velocity = playerMoveVector;


    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    //Hi
}
