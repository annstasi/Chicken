using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float normalSpeed;
    public float turnSpeed = 50f;
    Animator anim;
    public bool isGrounded = true;
    public float jumpForce = 250;
    private Rigidbody rb;

    void Start()
    {
        speed = 0f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit rh;
        if (Physics.Raycast(ray, out rh, 0.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        // ControllPlayer(); //для передвижения на компьютере
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y);
    }

    public void OnJumpButton()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    public void OnLeftButton()
    {
        if (speed >= 0f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            anim.SetInteger("run", 1);
            speed = -normalSpeed;
        }
    }

    public void OnRightButton()
    {

        if (speed <= 0f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            anim.SetInteger("run", 1);
            speed = normalSpeed;
        }
    }

    public void OnButtonUp()
    {
        anim.SetInteger("run", 0);
        speed = 0f;
    }
    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("run", 1);
        }
        else
        {
            anim.SetInteger("run", 0);
        }

        transform.Translate(movement * 8 * Time.deltaTime, Space.World);
    }
}