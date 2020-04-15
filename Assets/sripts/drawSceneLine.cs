﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawSceneLine : MonoBehaviour
{
    public Transform from;
    public Transform to;
    // Start is called before the first frame update
    void OnDrawGizmosSelected()
    {
        if (from != null && to != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, to.position);
            Gizmos.DrawSphere(from.position, 0.15f);
            Gizmos.DrawSphere(to.position, 0.15f);
        }
    }

}
