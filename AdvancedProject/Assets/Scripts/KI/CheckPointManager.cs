using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPointManager : MonoBehaviour
{
    public float MaxTimeToReachNextCheckpoint = 30f;
    public float TimeLeft = 30f;

    public KIAgent kartAgent;
    public CheckPoint nextCheckPointToReach;

    private int CurrentCheckpointIndex;
    private List<CheckPoint> Checkpoints;
    private CheckPoint lastCheckpoint;

    [SerializeField]
    private AllCheckPoints m_allCheckPoint;


    public event Action<CheckPoint> reachedCheckpoint;

    void Start()
    {
        ResetCheckpoints();
    }

    public void ResetCheckpoints()
    {
        Checkpoints = m_allCheckPoint.checkPoints;
        CurrentCheckpointIndex = 0;
        TimeLeft = MaxTimeToReachNextCheckpoint;

        SetNextCheckpoint();
    }

    private void Update()
    {
        TimeLeft -= Time.deltaTime;

        if (TimeLeft < 0f)
        {
            kartAgent.AddReward(-1f);
            kartAgent.EndEpisode();
        }
    }

    public void CheckPointReached(CheckPoint checkpoint)
    {
        if (nextCheckPointToReach != checkpoint) return;

        lastCheckpoint = Checkpoints[CurrentCheckpointIndex];
        reachedCheckpoint?.Invoke(checkpoint);
        CurrentCheckpointIndex++;

        if (CurrentCheckpointIndex >= Checkpoints.Count)
        {
            kartAgent.AddReward(0.5f);
            kartAgent.EndEpisode();
        }
        else
        {
            kartAgent.AddReward((0.5f) / Checkpoints.Count);
            SetNextCheckpoint();
        }
    }

    private void SetNextCheckpoint()
    {
        if (Checkpoints.Count > 0)
        {
            TimeLeft = MaxTimeToReachNextCheckpoint;
            nextCheckPointToReach = Checkpoints[CurrentCheckpointIndex];

        }
    }
}
