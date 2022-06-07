using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_speed;

    [SerializeField]
    private Rigidbody2D m_rb;

    [SerializeField]
    private PassageGenerator m_generator;

    private void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScenesManager.Instance.LoadMenu();
        }
    }

    private void Movement()
    {
        Vector2 dir = transform.up * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        dir = dir.normalized * m_speed;
        m_rb.velocity = dir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            m_generator.Replace();
        }
    }
}
