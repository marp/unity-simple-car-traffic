using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarSystem : MonoBehaviour
{
    [SerializeField] public WaypointGizmos waypoints;

    [SerializeField] private Transform _currentWaypoint;

    [SerializeField] private float distanceThreshold = 0.1f;

    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;

    public bool canMove = true;
    public void Start()
    {
        _currentWaypoint = waypoints.GetNextWaypoint(_currentWaypoint);
        transform.position = _currentWaypoint.position;
        
        _currentWaypoint = waypoints.GetNextWaypoint(_currentWaypoint);
        
    }

    public void StartTrack()
    {
        _currentWaypoint = waypoints.GetNextWaypoint(null);
    }

    
    void Update()
    {
        if (_currentWaypoint && canMove)
        {
            DrawLine();
            transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint.transform.position,
                moveSpeed * Time.deltaTime);
            RotateTowardsTarget(_currentWaypoint.transform);
        }
        
        if (_currentWaypoint && Vector2.Distance(transform.position, _currentWaypoint.position)  < distanceThreshold)
        {
            _currentWaypoint = waypoints.GetNextWaypoint(_currentWaypoint);
        }

    }
    
    void DrawLine()
    {
        if(_currentWaypoint) Debug.DrawLine(transform.position, _currentWaypoint.transform.position, Color.green);
    }

    
    private void RotateTowardsTarget(Transform target)
    {
        var offset = 90f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}