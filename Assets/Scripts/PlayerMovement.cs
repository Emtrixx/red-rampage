using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveVec;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float recoil = 0.2f;

    Vector2 mousePos;
    bool shooting;
    public Camera cam;


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVec * moveSpeed * Time.fixedDeltaTime);

        if(shooting)
        {
            rb.MovePosition(rb.position - ((Vector2)transform.up * recoil));
            shooting = false;
        }

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void OnMove(InputValue input)
    {
        //rb.velocity = moveVec * moveSpeed;
        moveVec = input.Get<Vector2>();
    }

    public void OnMousePosition(InputValue input)
    {
        mousePos = cam.ScreenToWorldPoint(input.Get<Vector2>());
    }

    public void OnShoot(InputValue input)
    {
        Debug.Log("Shoot");
        shooting = true;
    }
}
