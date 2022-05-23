using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => _instance; }
    public Transform PlayerSpawnPoint { get => m_playerSpawnPoint; set => m_playerSpawnPoint = value; }
    public Transform KiSpawnPoint { get => m_kiSpawnPoint; set => m_kiSpawnPoint = value; }
    public List<GameObject> Obstacles { get => m_obstacles; set => m_obstacles = value; }

    private static GameManager _instance;

    [SerializeField]
    private Transform m_playerSpawnPoint;
    [SerializeField]
    private Transform m_kiSpawnPoint;

    [SerializeField]
    private List<GameObject> m_obstacles = new List<GameObject>();

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
