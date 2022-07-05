using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCondition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("KI"))
        {
            //Herausfinden, wer gewonnen hat
            if (collision.TryGetComponent<PlayerController>(out PlayerController player))
            {
                HighscoreManager.Instance.AddPlayerWin();
                ScenesManager.Instance.LoadWin();
            }
            else
            {
                KIAgent agent = collision.GetComponent<KIAgent>();
                HighscoreManager.Instance.AddKIWin();
                ScenesManager.Instance.LoadLose();
            }
        }
    }
}
