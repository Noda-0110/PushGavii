using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLockX : MonoBehaviour
{
    [SerializeField] private float _minX = -1;
    [SerializeField] private float _maxX = 1;
    void Update()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);

        transform.position = pos;
        
    }
}
