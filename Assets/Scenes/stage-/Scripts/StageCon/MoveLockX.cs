using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLockY : MonoBehaviour
{
    [SerializeField] private float _minY = -1;
    [SerializeField] private float _maxY = 1;
    void Update()
    {
        var pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);

        transform.position = pos;
        
    }
}
