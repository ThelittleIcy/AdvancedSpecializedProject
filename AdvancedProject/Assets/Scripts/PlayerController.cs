using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_speed;

    [SerializeField]
    private Rigidbody2D m_rb;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {



        Vector2 dir = transform.up * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        dir = dir.normalized * m_speed;
        m_rb.velocity = dir;
    }
}
