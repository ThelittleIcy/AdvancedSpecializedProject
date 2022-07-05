using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCheckPoints : MonoBehaviour
{
    public List<CheckPoint> checkPoints;

    private void Awake()
    {
        checkPoints = new List<CheckPoint>(GetComponentsInChildren<CheckPoint>());
    }
}
