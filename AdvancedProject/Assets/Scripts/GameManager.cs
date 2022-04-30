using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => _instance; }
    public Transform PlayerSpawnPoint { get => m_playerSpawnPoint; set => m_playerSpawnPoint = value; }
    public Transform KiSpawnPoint { get => m_kiSpawnPoint; set => m_kiSpawnPoint = value; }

    private static GameManager _instance;

    [SerializeField]
    private Transform m_playerSpawnPoint;
    [SerializeField]
    private Transform m_kiSpawnPoint;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
