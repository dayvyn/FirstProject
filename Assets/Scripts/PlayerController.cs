using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    Camera mainCam;
    float forwardBack;
    float leftRight;
    [SerializeField] float moveSpeed;
    [SerializeField] int jumpForce;
    Animator playerAnimator;
    bool groundCheck = false;
    public UnityAction Hurt;
    bool damaged = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        playerRB = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        leftRight = Input.GetAxis("Horizontal");
        forwardBack = Input.GetAxis("Vertical");

        var camForward = mainCam.transform.forward;
        var camRight = mainCam.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        var playerMoveVector = camForward * forwardBack + camRight * leftRight;

        playerRB.velocity = new Vector3(playerMoveVector.x * moveSpeed, playerRB.velocity.y, playerMoveVector.z * moveSpeed);

        playerAnimator.SetInteger("speed", Mathf.CeilToInt(Mathf.Abs(playerRB.velocity.x) + Mathf.Abs(playerRB.velocity.z)));
        playerAnimator.SetInteger("fallingSpeed", Mathf.CeilToInt(playerRB.velocity.y));

    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        StartCoroutine(JumpRoutine());
    }
    //Hi
    IEnumerator JumpRoutine()
    {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnimator.SetBool("jumped", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("jumped", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            playerAnimator.SetBool("grounded", true);
            groundCheck = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            groundCheck = false;
            playerAnimator.SetBool("grounded", false );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && damaged == false)
        {
            Hurt.Invoke();
            StartCoroutine(PlayerDamaged());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7 && damaged == false)
        {
            Hurt.Invoke();
            StartCoroutine(PlayerDamaged());
        }
    }

    IEnumerator PlayerDamaged()
    {
        damaged = true;
        yield return new WaitForSeconds(2);
        damaged = false;
    }
}
