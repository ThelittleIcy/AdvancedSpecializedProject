using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class KIAgent : Agent
{
    public KI_Movement m_movement;
    public CheckPointManager m_checkPointManager;

    public override void Initialize()
    {
        m_movement = GetComponent<KI_Movement>();
    }

    public override void OnEpisodeBegin()
    {
        m_checkPointManager.ResetCheckpoints();
        m_movement.Respawn();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        Vector3 diff = m_checkPointManager.nextCheckPointToReach.transform.position - transform.position;
        sensor.AddObservation(diff /20f);

        AddReward(-0.001f);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        var input = actions.ContinuousActions;
        Vector3 dir = new Vector3(input[0], input[1], 0);
        m_movement.Movement(dir);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AddReward(-0.2f);
            m_movement.UpdatePassages();
            EndEpisode();
        }
    }
}
