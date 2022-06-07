using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCondition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Herausfinden, wer gewonnen hat
            if (collision.TryGetComponent<PlayerController>(out PlayerController player))
            {
                Debug.Log("Gewonnen");
                ScenesManager.Instance.LoadWin();
            }
            else
            {
                Debug.Log("Verloren");
                ScenesManager.Instance.LoadLose();
            }
        }
    }
}
