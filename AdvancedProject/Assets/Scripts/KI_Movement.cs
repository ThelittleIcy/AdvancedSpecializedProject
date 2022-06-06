using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using TMPro;

public class KI_Movement : Agent
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform respawn;

    [SerializeField]
    private TMP_Text m_loss;
    [SerializeField]
    private TMP_Text m_win;
    [SerializeField]
    private ScriptableInt m_lossCounter;
    [SerializeField]
    private ScriptableInt m_winCounter;

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private PassageGenerator m_passage;
    public override void OnEpisodeBegin()
    {
        this.transform.position = respawn.position;
        m_passage.Replace();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(target.transform.position);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveY = actions.ContinuousActions[1];

        transform.position += new Vector3(moveX, moveY, 0) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {

            SetReward(+1f);
            //m_winCounter.Value++;
            //m_win.text = m_winCounter.Value.ToString();
            EndEpisode();
            Debug.Log("Won");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))
        //{
        //    SetReward(-1f);
        //    //m_lossCounter.Value++;
        //    //m_loss.text = m_lossCounter.Value.ToString();
        //    EndEpisode();
        //}
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SetReward(-1f);
            //m_lossCounter.Value++;
            //m_loss.text = m_lossCounter.Value.ToString();
            Debug.Log("Lost");
            EndEpisode();
        }
    }
}
