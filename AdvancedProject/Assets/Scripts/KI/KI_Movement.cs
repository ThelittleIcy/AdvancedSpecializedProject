using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KI_Movement : MonoBehaviour
{
    [SerializeField]
    private Transform respawn;


    [SerializeField]
    private float moveSpeed = 3f;


    [SerializeField]
    private List<PassageGenerator> m_passages;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    
    public void Movement(Vector3 _dir)
    {
        transform.position += _dir * Time.deltaTime * MoveSpeed;
    }

    public void Respawn()
    {
        transform.position = respawn.position;
    }

    public void UpdatePassages()
    {
        foreach (PassageGenerator passage in m_passages)
        {
            passage.Replace();
        }
    }
}
