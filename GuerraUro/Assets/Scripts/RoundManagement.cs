using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManagement : MonoBehaviour
{
    protected enum RoundsSM
    {
        Building,
        Attacking
    }

    RoundsSM m_currentMode = RoundsSM.Building;
    // Update is called once per frame
    void Update()
    {
        switch (m_currentMode)
        {
            case RoundsSM.Building:
                break;
            case RoundsSM.Attacking:
                break;
            default:
                break;
        }
    }
}
