using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLogic : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
            {
                //Respawn Player
                collision.gameObject.transform.position = GameManager.Instance.PlayerSpawnPoint.position;
            }
            else
            {
                //Respawn KI
                collision.gameObject.transform.position = GameManager.Instance.KiSpawnPoint.position;
            }
        }
    }
}
