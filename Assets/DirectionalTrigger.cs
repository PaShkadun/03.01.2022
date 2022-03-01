using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalTrigger : MonoBehaviour
{
    [Range(0f, 1f)] [SerializeField] private float threshold;
    [SerializeField] private GameObject second;
    [SerializeField] private float cos;
    
    private void OnDrawGizmos()
    {
        //_World
        var norm = (second.transform.position - transform.position).normalized;
        cos = norm.x;
        
        if (cos >= threshold)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, second.transform.position);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, second.transform.position);
        }
    }
}