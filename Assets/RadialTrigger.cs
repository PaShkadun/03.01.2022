using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RadialTrigger : MonoBehaviour
{
    [SerializeField] private GameObject second;
    [SerializeField] private float radius;
    
    private void OnDrawGizmos()
    {
        var distanse = transform.position - second.transform.position;
        var distanseLength = Mathf.Sqrt(Mathf.Pow(distanse.x, 2) + Mathf.Pow(distanse.y, 2));

        if (distanseLength < radius)
        {
            Handles.color = Color.white;
            Handles.DrawWireDisc(transform.position, Vector3.back, radius);
        }
        else
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(transform.position, Vector3.back, radius);
        }
        
        Gizmos.DrawLine(transform.position, second.transform.position);
    }
}
