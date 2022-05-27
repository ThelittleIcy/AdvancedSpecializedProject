using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Data",fileName =("ScriptableInt"))]
public class ScriptableInt : ScriptableObject
{
    [SerializeField]
    private int m_value;

    public int Value { get => m_value; set => m_value = value; }
}
